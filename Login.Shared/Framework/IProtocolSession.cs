namespace Login.Shared.Framework
{
    public interface IProtocolSession : IDisposable
	{
		IRequestManager RequestManager { get; }
		Task WaitForSessionToEnd();
	}
}
