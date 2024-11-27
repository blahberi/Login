namespace Login.Client.Views
{
	partial class LoginView
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            RegisterLabel = new GruvboxLink();
            PasswordText = new GruvboxTextBox();
            PasswordLabel = new GruvboxLabel();
            UserNameText = new GruvboxTextBox();
            UserNameLabel = new GruvboxLabel();
            LoginButton = new GruvboxButton();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(RegisterLabel);
            panel1.Controls.Add(PasswordText);
            panel1.Controls.Add(PasswordLabel);
            panel1.Controls.Add(UserNameText);
            panel1.Controls.Add(UserNameLabel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 126);
            panel1.TabIndex = 0;
            // 
            // RegisterLabel
            // 
            RegisterLabel.ActiveLinkColor = Color.FromArgb(211, 134, 155);
            RegisterLabel.AutoSize = true;
            RegisterLabel.Dock = DockStyle.Bottom;
            RegisterLabel.Font = new Font("Microsoft Sans Serif", 10F);
            RegisterLabel.LinkColor = Color.FromArgb(131, 165, 152);
            RegisterLabel.Location = new Point(0, 106);
            RegisterLabel.Margin = new Padding(4, 0, 4, 0);
            RegisterLabel.Name = "RegisterLabel";
            RegisterLabel.Size = new Size(185, 20);
            RegisterLabel.TabIndex = 4;
            RegisterLabel.TabStop = true;
            RegisterLabel.Text = "Don't have an account?";
            RegisterLabel.LinkClicked += RegisterLabel_LinkClicked;
            // 
            // PasswordText
            // 
            PasswordText.BackColor = Color.FromArgb(235, 219, 178);
            PasswordText.BorderStyle = BorderStyle.FixedSingle;
            PasswordText.Dock = DockStyle.Top;
            PasswordText.Font = new Font("Microsoft Sans Serif", 11F);
            PasswordText.ForeColor = Color.FromArgb(40, 40, 40);
            PasswordText.Location = new Point(0, 78);
            PasswordText.Margin = new Padding(4, 5, 4, 5);
            PasswordText.Name = "PasswordText";
            PasswordText.Size = new Size(400, 28);
            PasswordText.TabIndex = 3;
            PasswordText.UseSystemPasswordChar = true;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Dock = DockStyle.Top;
            PasswordLabel.Font = new Font("Microsoft Sans Serif", 12F);
            PasswordLabel.ForeColor = Color.FromArgb(251, 241, 199);
            PasswordLabel.Location = new Point(0, 53);
            PasswordLabel.Margin = new Padding(4, 0, 4, 0);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(98, 25);
            PasswordLabel.TabIndex = 2;
            PasswordLabel.Text = "Password";
            // 
            // UserNameText
            // 
            UserNameText.BackColor = Color.FromArgb(235, 219, 178);
            UserNameText.BorderStyle = BorderStyle.FixedSingle;
            UserNameText.Dock = DockStyle.Top;
            UserNameText.Font = new Font("Microsoft Sans Serif", 11F);
            UserNameText.ForeColor = Color.FromArgb(40, 40, 40);
            UserNameText.Location = new Point(0, 25);
            UserNameText.Margin = new Padding(4, 5, 4, 5);
            UserNameText.Name = "UserNameText";
            UserNameText.Size = new Size(400, 28);
            UserNameText.TabIndex = 1;
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Dock = DockStyle.Top;
            UserNameLabel.Font = new Font("Microsoft Sans Serif", 12F);
            UserNameLabel.ForeColor = Color.FromArgb(251, 241, 199);
            UserNameLabel.Location = new Point(0, 0);
            UserNameLabel.Margin = new Padding(4, 0, 4, 0);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(102, 25);
            UserNameLabel.TabIndex = 0;
            UserNameLabel.Text = "Username";
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.FromArgb(211, 134, 155);
            LoginButton.Dock = DockStyle.Bottom;
            LoginButton.FlatStyle = FlatStyle.Flat;
            LoginButton.Font = new Font("Microsoft Sans Serif", 12F);
            LoginButton.ForeColor = Color.FromArgb(40, 40, 40);
            LoginButton.Location = new Point(0, 177);
            LoginButton.Margin = new Padding(4, 5, 4, 5);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(400, 54);
            LoginButton.TabIndex = 1;
            LoginButton.Text = "Log In";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(panel1);
            Controls.Add(LoginButton);
            Margin = new Padding(4, 5, 4, 5);
            Name = "LoginView";
            Size = new Size(400, 231);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GruvboxTextBox PasswordText;
        private GruvboxLabel PasswordLabel;
        private GruvboxTextBox UserNameText;
        private GruvboxLabel UserNameLabel;
        private GruvboxButton LoginButton;
        private GruvboxLink RegisterLabel;
    }
}
