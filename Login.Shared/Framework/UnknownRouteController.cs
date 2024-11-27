using System.Net;
using Login.Shared.DTOs;

namespace Login.Shared.Framework
{
    internal class UnknownRouteController : IController
	{
		public Task<Response> ProcessRequestAsync(Message message, CancellationToken cancellation)
		{
			return Response.Error($"{message.Path} not found", HttpStatusCode.NotFound).AsTask();
		}
	}
}