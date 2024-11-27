using System;
using System.Windows.Forms;

namespace Login.Client.Views
{
	internal partial class LoginView : UserControl
	{
		private readonly UIManager gameUIManager;
		public LoginView(UIManager gameUIManager)
		{
			this.gameUIManager = gameUIManager;
			this.InitializeComponent();
		}

		private async void LoginButton_Click(object sender, EventArgs e)
		{
			string username = this.UserNameText.Text;
			string password = this.PasswordText.Text;

			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
			{
				MessageBox.Show("Please fill in all fields.");
				return;
			}

			this.LoginButton.Enabled = false;
			await this.gameUIManager.TrySignIn(username, password);
			this.LoginButton.Enabled = true;
		}

		private void RegisterLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.gameUIManager.ClientRegister();
		}
	}
}
