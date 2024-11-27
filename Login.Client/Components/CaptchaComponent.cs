using Login.Shared.DTOs.Captcha;
using Login.Shared.Framework;

namespace Login.Client.Components
{
    internal partial class CaptchaComponent : UserControl
    {
        private readonly UIManager uiManager;

        public CaptchaComponent(UIManager uiManager)
        {
            this.CaptchaLoaded = false;
            this.uiManager = uiManager;
            InitializeComponent();
        }

        public Captcha? Captcha { get; private set; }
        public bool CaptchaLoaded { get; private set; }

        private async void CaptchaComponent_Load(object sender, EventArgs e)
        {
            Result<Captcha> getCaptchaResult = await this.uiManager.TryGetCaptcha();
            if (!getCaptchaResult.Success)
            {
                this.Captcha = null;
                this.CaptchaLoaded = false;
                return;
            }
            this.Captcha = getCaptchaResult.Value;
            this.captchaPictureBox.Image = this.Captcha.Bitmap;
            this.CaptchaLoaded = true;
        }
    }
}
