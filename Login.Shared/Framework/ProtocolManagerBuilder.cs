using Cornflakes;

namespace Login.Shared.Framework
{
	public class ProtocolManagerBuilder<TConnectionContext> : IProtocolManagerBuilder<TConnectionContext> where TConnectionContext : ConnectionContext, new()
	{
		private readonly ControllerFactory<TConnectionContext> controllerFactory;

		public ProtocolManagerBuilder()
		{
			this.Services = new ServiceCollection();
			this.controllerFactory = new ControllerFactory<TConnectionContext>();
		}

		public IServiceCollection Services { get; }

		public IProtocolManager Build()
		{
			IProviderOfServices serviceProvider = new ServiceProviderBuilder()
				.RegisterServices(this.Services)
				.Build();
			return new ProtocolManager<TConnectionContext>(this.controllerFactory, serviceProvider);
		}

		public IProtocolManagerBuilder<TConnectionContext> RegisterController(string path, GenerateController<TConnectionContext> controllerFactory)
		{
			this.controllerFactory.RegisterController(path, controllerFactory);
			return this;
		}
	}
}
