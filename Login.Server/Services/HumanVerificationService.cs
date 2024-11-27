using Login.Shared.DTOs.Captcha;

namespace Login.Server.Services
{
    internal class HumanVerificationService : IHumanVerificationService
    {
        private readonly ICaptchaService captchaImageService;
        private readonly Dictionary<Guid, string> captchaAnswers = new Dictionary<Guid, string>();
        private readonly HashSet<VerificationCertificate> verificationTokens = new HashSet<VerificationCertificate>();

        public HumanVerificationService(ICaptchaService captchaService)
        {
            this.captchaImageService = captchaService;
        }

        public Captcha StartCaptchaSession()
        {
            string text = this.captchaImageService.GenerateRandomText(6);
            Captcha captcha = new Captcha
            {
                Guid = Guid.NewGuid(),
                Bitmap = this.captchaImageService.GenerateCaptchaImage(text)
            };
            this.captchaAnswers.Add(captcha.Guid, text);
            return captcha;
        }

        public bool TrySubmitAnswer(CaptchaAnswer answer, out VerificationCertificate verificationToken)
        {
            if (this.captchaAnswers[answer.Guid] != answer.Answer)
            {
                verificationToken = VerificationCertificate.Empty;
                return false;
            }
            verificationToken = VerificationCertificate.NewVeriricationToken();
            this.verificationTokens.Add(verificationToken);
            return true;
        }

        public bool TryVerifying(VerificationCertificate verificationToken)
        {
            if (!this.verificationTokens.Contains(verificationToken))
            {
                return false;
            }
            this.verificationTokens.Remove(verificationToken);
            return true;
        }
    }
}
