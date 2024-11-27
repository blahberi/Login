using Login.Shared.DTOs.Captcha;

namespace Login.Client.Components
{
    internal partial class CaptchaComponent : UserControl
    {
        private readonly UIManager uiManager;
        private VerificationCertificate? verificationCerticiate;

        public CaptchaComponent(UIManager uiManager)
        {
            this.uiManager = uiManager;
            InitializeComponent();
        }

        public Captcha? Captcha { get; private set; }

        private async void CaptchaComponent_Load(object sender, EventArgs e)
        {
            this.Captcha = await this.uiManager.GetCaptcha();
            if (this.Captcha == null)
            {
                return;
            }
            this.captchaPictureBox.Image = this.Captcha.Bitmap;
        }

        private async void verifyButton_Click(object sender, EventArgs e)
        {
            if (this.Captcha == null)
            {
                return;
            }

            if (this.answerTextbox.Text != String.Empty) 
            {
                this.verificationCerticiate = await this.uiManager.AnswerCaptcha(this.Captcha.Guid, this.answerTextbox.Text);
            }
        }
    }
}
