using System.Net;
using System.Text.Json;
using Cornflakes;
using Login.Shared.DTOs;

namespace Login.Shared.Framework
{

    internal class ProtocolSession<TConnectionContext> : IProtocolSession, IRequestManager where TConnectionContext : ConnectionContext, new()
	{
		private readonly IControllerFactory<TConnectionContext> controllerFactory;
		private readonly TConnectionContext connectionContext;
		private readonly ISessionComm sessionComm;
		private readonly Dictionary<Guid, TaskCompletionSource<string>> pendingRequests; // Used to store requests that are waiting for a response
		private readonly Dictionary<Guid, CancellationTokenSource> pendingCancellableRequests; // Used to cancel requests that are being handled
		private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);  // Binary semaphore for synchronizing writes to the stream
		private Task messageLoop;

		public ProtocolSession(
			IControllerFactory<TConnectionContext> controllerFactory, 
			IProviderOfServices serviceProvider, 
			ISessionComm sessionComm)
		{
			this.connectionContext = new TConnectionContext();
			this.connectionContext.RequestManager = this;
			this.connectionContext.ServiceProvider = serviceProvider;

			this.controllerFactory = controllerFactory;
			this.sessionComm = sessionComm;

			this.pendingRequests = new Dictionary<Guid, TaskCompletionSource<string>>();
			this.pendingCancellableRequests = new Dictionary<Guid, CancellationTokenSource>();
		}

		public IRequestManager RequestManager => this;

		public void Dispose()
		{
			this.CancelAllPendingRequests();
			this.sessionComm.Dispose();
			this.connectionContext.Dispose();
		}

		public Task WaitForSessionToEnd()
		{
			return this.messageLoop;
		}

		public void StartMessageLoop()
		{
			this.messageLoop = this.HandleMessageLoopAsync();
		}

		public async Task<string> SendRequest(string path, string method, object requestBody = null, CancellationToken cancellationToken = default)
		{
			Guid messageId = Guid.NewGuid();

			TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
			lock (this.pendingRequests)
			{
				this.pendingRequests.Add(messageId, tcs);
			}

			string body = requestBody != null ? JsonSerializer.Serialize(requestBody) : string.Empty;

			Message message = new Message { Path = path, Method = method, Body = body };
			message.MessageId = messageId;

			cancellationToken.Register(async () =>
			{
				await this.SendMessage(new Message { Path = Paths.Cancellation, Method = Methods.Cancellation.Cancel }, messageId).ConfigureAwait(false);
			});

			await this.SendMessage(message, messageId).ConfigureAwait(false);

			return await tcs.Task.ConfigureAwait(false);
		}

		private async Task HandleMessageLoopAsync()
		{
			try
			{
				while (true) // Keep reading as long as the connection is open
				{
					byte[] jsonRequestBytes = await this.sessionComm.ReadMessageAsync(); // Read message from the other side.
					if (jsonRequestBytes.Length == 0)
					{
						break; // If the other side closes connection, exit loop
					}

					string jsonRequest = System.Text.Encoding.UTF8.GetString(jsonRequestBytes); // Convert the bytes to a string
					Message request = JsonSerializer.Deserialize<Message>(jsonRequest);
					Console.WriteLine($"Received: Id:{request.MessageId} Method={request.Method}, Path={request.Path}, Body={request.Body}");

					switch (request.Path)
					{
						case Paths.Response:
							this.HandleRequestReponse(request);
							break;
						case Paths.Cancellation:
							this.HandleRequestCancellation(request);
							break;
						default:
							this.HandleIncommingRequest(request);
							break;
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Exception: {e.Message}");
			}
			finally
			{
				Console.WriteLine("Closing connection.");
				this.Dispose();
			}
		}

		private void CancelAllPendingRequests()
		{
			this.pendingRequests.Values.ForEach(tcs => tcs.SetException(new ObjectDisposedException("Disconnected")));
			this.pendingRequests.Clear();
		}

		private void HandleRequestReponse(Message response)
		{
			TaskCompletionSource<string> tcs;
			lock (this.pendingRequests)
			{
				// Find request inside pending requests
				if (!this.pendingRequests.TryGetValue(response.MessageId, out tcs))
				{
					return;
				}
				this.pendingRequests.Remove(response.MessageId);
			}

			if (response.Method == Methods.Response.Success)
			{
				tcs.SetResult(response.Body);
			}
			else
			{
				FailureBody failureBody = JsonSerializer.Deserialize<FailureBody>(response.Body);
				Exception exception = HttpStatusExceptionMapper.GetExceptionForStatusCode(failureBody.HttpStatusCode, failureBody.ErrorMessage);
				tcs.SetException(exception);
			}
		}

		private void HandleRequestCancellation(Message request)
		{
			CancellationTokenSource cancellationTokenSource;
			lock (this.pendingCancellableRequests)
			{
				if (!this.pendingCancellableRequests.TryGetValue(request.MessageId, out cancellationTokenSource))
				{
					return;
				}
			}

			cancellationTokenSource.Cancel();
		}

		private async void HandleIncommingRequest(Message request)
		{
			// We want to to handle the request logic asynchornously without blocking the thread, but we do not want to wait for it
			// so we can continue to perform the next read on the TCP connection. So this is a void method which is not awaited by the caller.
			// Never do async work inside an async void method. So move the work into the HandleIncommingRequestAsync and await it here.
			// See: https://hackernoon.com/how-to-tame-the-async-void-in-c
			try
			{
				await this.HandleIncommingRequestAsync(request);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to handle request: {ex.Message}");
			}
		}

		private async Task HandleIncommingRequestAsync(Message request)
		{
			Response response;
			IController controller = this.controllerFactory.CreateController(this.connectionContext, request.Path);

			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			lock (this.pendingCancellableRequests)
			{
				this.pendingCancellableRequests.Add(request.MessageId, cancellationTokenSource);
			}

			try
			{
				response = await controller.ProcessRequestAsync(request, cancellationTokenSource.Token);
			}
			catch (UnauthorizedAccessException)
			{
				response = Response.Unauthorized;
			}
			catch (OperationCanceledException)
			{
				response = Response.Error("Request was cancelled.", HttpStatusCode.RequestTimeout);
			}
			catch (ObjectDisposedException)
			{
				response = Response.Error("Resource is gone.", HttpStatusCode.Gone);
			}
			catch (Exception ex)
			{
				response = Response.Error("Error in request processing.", HttpStatusCode.InternalServerError);
				Console.WriteLine(ex.Message);
			}
			finally
			{
				lock (this.pendingCancellableRequests)
				{
					this.pendingCancellableRequests.Remove(request.MessageId);
				}
			}

			// Respond
			Message responseMessage = response.AsMessage();

			try
			{
				await this.SendMessage(responseMessage, request.MessageId);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to send response: {ex.Message}");
			}
		}

		private async Task SendMessage(Message message, Guid messageId)
		{
			message.MessageId = messageId;

			Console.WriteLine($"Going to send: ID: {message.MessageId} Method={message.Method}, Path={message.Path}, Body={message.Body}");

			string messageString = JsonSerializer.Serialize(message);

			await this.semaphore.WaitAsync();
			try
			{
				Console.WriteLine($"Sending: {messageString}");
				byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(messageString);
				await this.sessionComm.WriteMessageAsync(messageBytes);
			}
			finally
			{
				this.semaphore.Release();
			}
		}
	}
}
