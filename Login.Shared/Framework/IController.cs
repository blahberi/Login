using Login.Shared.DTOs;

namespace Login.Shared.Framework
{
    public interface IController
	{
		Task<Response> ProcessRequestAsync(Message message, CancellationToken cancellationToken);
	}
}
