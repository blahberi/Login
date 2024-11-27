using Login.Shared.DTOs;
using Login.Shared.Framework;

namespace Login.Server.Controllers
{
	internal static class ControllerRegistration
	{
		public static IProtocolManagerBuilder<ServerConnectionContext> RegisterControllers(this IProtocolManagerBuilder<ServerConnectionContext> builder)
		{
			return builder
				.RegisterController(Paths.Users, connectionContext => new UserController(connectionContext))
				.RegisterController(Paths.HumanVerification, connectionContext => new HumanVerificationController(connectionContext));
		}
	}
}
