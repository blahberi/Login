using Cornflakes;
using Login.Server.DataAccess;
using Login.Shared.Framework;

namespace Login.Server.Services
{
	internal static class ServiceRegistration
	{
		public static IProtocolManagerBuilder<ServerConnectionContext> RegisterServices(this IProtocolManagerBuilder<ServerConnectionContext> builder)
		{
			builder.Services
				.AddSingleton<IDataAccess, SqlDataAccess>()
				.AddSingleton<ICaptchaService, CaptchaService>()
				.AddSingleton<IHumanVerificationService, HumanVerificationService>()
				.AddSingleton<IUserService, UserService>()
				.AddSingleton<IEmailService, EmailService>();

			return builder;
		}
	}
}
