using Login.Shared.DTOs.Captcha;

namespace Login.Client.Services
{
    public interface IHumanVerificationService
    {
        void AddVerificationCertificate(VerificationCertificate verificationCertificate);
        bool TryGetVerificationCertificate(out VerificationCertificate? verificationCertificate);
    }
}