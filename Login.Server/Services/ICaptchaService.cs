using System.Drawing;

namespace Login.Server.Services
{
    public interface ICaptchaService
    {
        Bitmap GenerateCaptchaImage(string text);
        string GenerateRandomText(int length);
    }
}