using Login.Shared.DTOs.Captcha;

namespace Login.Server.Services
{
    internal class HumanVerificationService : IHumanVerificationService
    {
        private readonly ICaptchaService captchaImageService;
        private readonly Dictionary<Guid, string> captchaAnswers = new Dictionary<Guid, string>();
        private readonly HashSet<Guid> verificationTokens = new HashSet<Guid>();

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

        public bool TrySubmitAnswer(CaptchaAnswer answer, out Guid verificationToken)
        {
            if (this.captchaAnswers[answer.Guid] != answer.Answer)
            {
                verificationToken = Guid.Empty;
                return false;
            }
            verificationToken = Guid.NewGuid();
            this.verificationTokens.Add(verificationToken);
            return true;
        }

        public bool TryVerifying(Guid verificationToken)
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
