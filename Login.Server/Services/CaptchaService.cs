using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;

namespace Login.Server.Services
{
    internal class CaptchaService : ICaptchaService
    {
        public Bitmap GenerateCaptchaImage(string text)
        {
            const int width = 150;
            const int height = 150;
            using Mat captchaMat = new Mat(new OpenCvSharp.Size(width, height), MatType.CV_8UC3, Scalar.White);
            HersheyFonts font = HersheyFonts.HersheySimplex;
            double fontSize = 0.7;
            int fontThickness = 2;

            // Calculate text size to center it
            OpenCvSharp.Size textSize = Cv2.GetTextSize(text, font, fontSize, fontThickness, out int baseline);
            int textX = (width - textSize.Width) / 2 - baseline;  // Center horizontally
            int textY = (height - textSize.Height) / 2; // Center vertically

            // Draw the text on the image
            Scalar textColor = new Scalar(0, 0, 0); // Black text
            Cv2.PutText(captchaMat, text, new OpenCvSharp.Point(textX, textY), font, fontSize, textColor, fontThickness);

            // Convert Mat to Bitmap
            Bitmap captchaBitmap = BitmapConverter.ToBitmap(captchaMat);
            return captchaBitmap;
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
