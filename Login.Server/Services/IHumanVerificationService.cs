using Login.Shared.DTOs.Captcha;

namespace Login.Server.Services
{
    internal interface IHumanVerificationService
    {
        Captcha StartCaptchaSession();
        bool TrySubmitAnswer(CaptchaAnswer answer, out VerificationCertificate verificationToken);
        bool TryVerifying(VerificationCertificate verificationToken);
    }
}
