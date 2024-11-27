using System.Text.Json;

namespace Login.Shared.Framework
{
    public static class IRequestManagerExtensions
	{
		public static async Task<TResponse> SendRequest<TResponse>(this IRequestManager requestManager, string path, string method, object requestBody = null, CancellationToken cancellationToken = default)
		{
			string responseString = await requestManager.SendRequest(path, method, requestBody, cancellationToken);

			if (responseString == null)
			{
				return default;
			}

			return JsonSerializer.Deserialize<TResponse>(responseString);
		}
	}
}
