using Cornflakes;

namespace Login.Shared.Framework
{
	public delegate IController GenerateController<TConnectionContext>(TConnectionContext connectionContext)
		where TConnectionContext : ConnectionContext;

	public interface IProtocolManagerBuilder<TConnectionContext> where TConnectionContext : ConnectionContext
	{
		IServiceCollection Services { get; }
		IProtocolManagerBuilder<TConnectionContext> RegisterController(string path, GenerateController<TConnectionContext> createController);
		IProtocolManager Build();
	}
}
