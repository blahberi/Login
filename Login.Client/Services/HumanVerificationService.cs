using Login.Shared;
using Login.Shared.DTOs.Captcha;
using Login.Shared.Framework;

namespace Login.Client.Services
{
    internal class HumanVerificationService : IHumanVerificationService
    {
        private readonly IProtocolSession session;

        public HumanVerificationService(IProtocolSession session)
        {
            this.session = session;
        }

        public async Task<Captcha> GetCaptcha()
        {
			try
			{
                TransferableCaptcha transferableCaptcha = await this.session.RequestManager.SendGetCaptchaRequest();
                return new Captcha()
                {
                    Guid = transferableCaptcha.Guid,
                    Bitmap = Base64ToBitmap(transferableCaptcha.Base64Bitmap)
                };
            }
            catch
			{
                return null;
			}
        }

        public async Task<VerificationCertificate> AnswerCaptcha(Guid guid, string answer)
        {
            try
            {
                VerificationCertificate verificationCertificate = await this.session.RequestManager.SendAnswerCaptchaReuqest(guid, answer);
            }
        }

        private Bitmap Base64ToBitmap(string base64string)
        {
            byte[] bytes = Convert.FromBase64String(base64string);
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                return new Bitmap(memoryStream);
            }
        }
    }
}
