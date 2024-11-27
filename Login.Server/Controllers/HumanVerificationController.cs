using Login.Server.Services;
using Login.Shared.DTOs;
using Login.Shared.DTOs.Captcha;
using Login.Shared.Framework;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Net;

namespace Login.Server.Controllers
{
    internal class HumanVerificationController : ServerControllerBase
    {
        public HumanVerificationController(ServerConnectionContext connectionContext) : base(connectionContext) { }

        public override async Task<Response> ProcessRequestAsync(Message message, CancellationToken cancellationToken)
        {
			switch (message.Method)
			{
				case Methods.Captcha.GetCaptcha:
					return await this.GetCaptcha(message);
				case Methods.Captcha.SubmitAnswer:
					return this.SubmitAnswer(message);
				default:
					return Response.Error("Method not allowed", HttpStatusCode.MethodNotAllowed);
			}
        }

        private async Task<Response> GetCaptcha(Message message)
        {
            Captcha captcha = this.GetService<IHumanVerificationService>().StartCaptchaSession();
            TransferableCaptcha transferableCaptcha = new TransferableCaptcha()
            {
                Guid = captcha.Guid,
                Base64Bitmap = await BitmapToBase64(captcha.Bitmap)
            };
            return Response.OK(transferableCaptcha);
        }

        private Response SubmitAnswer(Message message)
        {
            CaptchaAnswer answer = this.GetRequestBody<CaptchaAnswer>(message);
            bool result = this.GetService<IHumanVerificationService>().TrySubmitAnswer(answer, out Guid verificationToken);

            if (result == false)
            {
                return Response.Error("Human verification failed", HttpStatusCode.NotAcceptable);
            }

            return Response.OK(verificationToken);
        }

        private async Task<string> BitmapToBase64(Bitmap bitmap)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Png);
                memoryStream.Position = 0;
                byte[] bytes = new byte[memoryStream.Length];
                await memoryStream.ReadAsync(bytes, 0, bytes.Length);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
