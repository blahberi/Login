using OpenCvSharp;
using System.Drawing;

namespace Login.Server.Services
{
    internal class CaptchaService : ICaptchaService
    {
        public Bitmap BadGenerateCaptchaImage(string text)
        {
            int width = 150;
            int height = 150;
            Bitmap bitmap = new Bitmap(width, height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);

                using (Font font = new Font("Arial", 24, FontStyle.Bold))
                {
                    using (Brush brush = new SolidBrush(Color.Black))
                    {
                        graphics.DrawString(text, font, brush, new PointF(10, 10));
                    }
                }
            }

            return bitmap;
        }

        public Bitmap GenerateCaptchaImage(string text)
        {
            const int width = 150;
            const int height = 150;
            using Mat captchaMat = new Mat(new OpenCvSharp.Size(width, height), MatType.CV_8UC3, Scalar.White);

        }

        public string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] text = new char[length];

            for (int i = 0; i < length; i++)
            {
                text[i] = chars[random.Next(chars.Length)];
            }

            return new string(text);
        }
    }
}
