using Cornflakes;

namespace Login.Shared.Framework
{
    public class ConnectionContext : IDisposable
	{
		public IRequestManager RequestManager { get; internal set; }

		public IProviderOfServices ServiceProvider { get; internal set; }

		public virtual void Dispose()
		{
			// Do nothing by default
			// This method is virtual so that derived classes can override it if they need to do something when the connection context is disposed
		}
	}
}
