using Cornflakes;

namespace Login.Client.Services
{
    public static class ServiceRegistration
    {
        public static IServiceProviderBuilder RegisterServices(this IServiceProviderBuilder builder)
        {
            return builder
                .RegisterSingleton<IHumanVerificationService, HumanVerificationService>();
        }
    }
}
