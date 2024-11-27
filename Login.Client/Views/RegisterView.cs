using Login.Client.Components;
using Login.Shared.DTOs.Captcha;

namespace Login.Client.Views
{
    internal partial class RegisterView : UserControl
    {
        private readonly UIManager uiManager;

        public RegisterView(UIManager uiManager)
        {
            this.InitializeComponent();
            this.uiManager = uiManager;
            this.CaptchaComponent = new CaptchaComponent(this.uiManager);
            this.CaptchaComponent.Dock = DockStyle.Bottom;
            this.panel1.Controls.Add(this.CaptchaComponent);
        }

        private async void RegisterButton_Click(object sender, System.EventArgs e)
        {
            string username = this.UserNameText.Text;
            string password = this.PasswordText.Text;
            string email = this.EmailText.Text;
            string firstName = this.FirstNameText.Text;
            string lastName = this.LastNameText.Text;
            string country = this.CountryText.Text;
            string city = this.CityText.Text;
            string gender = this.GenderCombo.Text;

            this.RegisterButton.Enabled = false;
            await this.uiManager.TryRegister(username, password, email, firstName, lastName, country, city, gender);
            this.RegisterButton.Enabled = true;
        }

        private void LoginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.uiManager.ClientReturnToLogin();
        }
    }
}
