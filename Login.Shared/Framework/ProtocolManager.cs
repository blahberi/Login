using Cornflakes;

namespace Login.Shared.Framework
{
    internal class ProtocolManager<TConnectionContext> : IProtocolManager where TConnectionContext : ConnectionContext, new()
	{
		private readonly IControllerFactory<TConnectionContext> controllerFactory;
		private readonly IProviderOfServices serviceProvider;

		public ProtocolManager(IControllerFactory<TConnectionContext> controllerFactory, IProviderOfServices serviceLocator)
		{
			this.controllerFactory = controllerFactory;
			this.serviceProvider = serviceLocator;
		}

		public IProtocolSession CreateSession(ISessionComm sessionComm)
		{
			ProtocolSession<TConnectionContext> protocolSession = new ProtocolSession<TConnectionContext>(this.controllerFactory, this.serviceProvider, sessionComm);

			protocolSession.StartMessageLoop();

			return protocolSession;
		}
	}
}
