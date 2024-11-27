using Login.Shared.DTOs.Captcha;

namespace Login.Client.Services
{
    public interface IHumanVerificationService
    {
        Task<Captcha> GetCaptcha();
    }
}