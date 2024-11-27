namespace Login.Shared.DTOs.Captcha
{
    public class TransferableCaptcha 
    {
        public Guid Guid { get; set; }
        public string Base64Bitmap { get; set; }
    }
}
