﻿using System.Drawing;
using System.Drawing.Drawing2D;

namespace Login.Server.Services
{
    internal class CaptchaService : ICaptchaService
    {
        public Bitmap GenerateCaptchaImage(string text)
        {
            const int width = 150;
            const int height = 150;
            const string fontFamilyName = "Ariel";
            //make the bitmap and the associated Graphics object
            Bitmap bm = new Bitmap(width, height);
            Graphics gr = Graphics.FromImage(bm);
            gr.SmoothingMode = SmoothingMode.HighQuality;
            RectangleF recF = new RectangleF(0, 0, width, height);
            Brush br;
            br = new HatchBrush(HatchStyle.SmallConfetti, Color.LightGray, Color.White);
            gr.FillRectangle(br, recF);
            SizeF text_size;
            Font the_font;
            float font_size = height + 1;
            do
            {
                font_size -= 1;
                the_font = new Font(fontFamilyName, font_size, FontStyle.Bold, GraphicsUnit.Pixel);
                text_size = gr.MeasureString(text, the_font);
            }
            while ((text_size.Width > width) || (text_size.Height > height));
            // Center the text.
            StringFormat string_format = new StringFormat();
            string_format.Alignment = StringAlignment.Center;
            string_format.LineAlignment = StringAlignment.Center;
            // Convert the text into a path.
            GraphicsPath graphics_path = new GraphicsPath();
            graphics_path.AddString(text, the_font.FontFamily, 1, the_font.Size, recF, string_format);
            //Make random warping parameters.
            Random rnd = new Random();
            PointF[] pts = { new PointF((float)rnd.Next(width) / 4, (float)rnd.Next(height) / 4), new PointF(width - (float)rnd.Next(width) / 4, (float)rnd.Next(height) / 4), new PointF((float)rnd.Next(width) / 4, height - (float)rnd.Next(height) / 4), new PointF(width - (float)rnd.Next(width) / 4, height - (float)rnd.Next(height) / 4) };
            Matrix mat = new Matrix();
            graphics_path.Warp(pts, recF, mat, WarpMode.Perspective, 0);
            // Draw the text.
            br = new HatchBrush(HatchStyle.LargeConfetti, Color.LightGray, Color.DarkGray);
            gr.FillPath(br, graphics_path);
            // Mess things up a bit.
            int max_dimension = System.Math.Max(width, height);
            for (int i = 0; i <= (int)width * height / 30; i++)
            {
                int X = rnd.Next(width);
                int Y = rnd.Next(height);
                int W = (int)rnd.Next(max_dimension) / 50;
                int H = (int)rnd.Next(max_dimension) / 50;
                gr.FillEllipse(br, X, Y, W, H);
            }
            for (int i = 1; i <= 5; i++)
            {
                int x1 = rnd.Next(width);
                int y1 = rnd.Next(height);
                int x2 = rnd.Next(width);
                int y2 = rnd.Next(height);
                gr.DrawLine(Pens.DarkGray, x1, y1, x2, y2);
            }
            for (int i = 1; i <= 5; i++)
            {
                int x1 = rnd.Next(width);
                int y1 = rnd.Next(height);
                int x2 = rnd.Next(width);
                int y2 = rnd.Next(height);
                gr.DrawLine(Pens.LightGray, x1, y1, x2, y2);
            }
            graphics_path.Dispose();
            br.Dispose();
            the_font.Dispose();
            gr.Dispose();
            return bm;
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
