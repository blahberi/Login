namespace Login.Shared.Framework
{
    public interface IRequestManager
	{
		Task<string> SendRequest(string path, string method, object requestBody = null, CancellationToken cancellationToken = default);
	}
}
