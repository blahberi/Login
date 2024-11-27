using System.Text.Json;
using Cornflakes;
using Login.Shared.DTOs;

namespace Login.Shared.Framework
{
    public abstract class ControllerBase<TConnectionContext> : IController where TConnectionContext : ConnectionContext
	{
		protected ControllerBase(TConnectionContext connectionContext)
		{
			this.ConnectionContext = connectionContext;
		}

		protected TConnectionContext ConnectionContext { get; }

		public abstract Task<Response> ProcessRequestAsync(Message message, CancellationToken cancellationToken);

		protected void GetService<T>(out T service)
		{
			service = this.ConnectionContext.ServiceProvider.GetService<T>();
		}

		protected T GetService<T>()
		{
			return this.ConnectionContext.ServiceProvider.GetService<T>();
		}

		protected T GetRequestBody<T>(Message message)
		{
			return JsonSerializer.Deserialize<T>(message.Body); }
	}
}
