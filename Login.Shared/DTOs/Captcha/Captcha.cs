using System.Drawing;

namespace Login.Shared.DTOs.Captcha
{
    public class Captcha
    {
        public Guid Guid { get; set; }
        public Bitmap Bitmap { get; set; }
    }
}
