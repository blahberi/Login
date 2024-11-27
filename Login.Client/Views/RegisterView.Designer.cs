using Login.Client.Components;

namespace Login.Client.Views
{
	partial class RegisterView
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
            PasswordText = new GruvboxTextBox();
            PasswordLabel = new GruvboxLabel();
            UserNameText = new GruvboxTextBox();
            UserNameLabel = new GruvboxLabel();
            panel1 = new Panel();
            panel3 = new Panel();
            GenderCombo = new GruvboxComboBox();
            GenderLabel = new GruvboxLabel();
            CityText = new GruvboxTextBox();
            CityLabel = new GruvboxLabel();
            CountryText = new GruvboxTextBox();
            CountryLabel = new GruvboxLabel();
            LastNameText = new GruvboxTextBox();
            LastNameLabel = new GruvboxLabel();
            FirstNameText = new GruvboxTextBox();
            FirstNameLabel = new GruvboxLabel();
            EmailText = new GruvboxTextBox();
            EmailLabel = new GruvboxLabel();
            RegisterButton = new GruvboxButton();
            LoginLink = new GruvboxLink();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // PasswordText
            // 
            PasswordText.BackColor = Color.FromArgb(235, 219, 178);
            PasswordText.BorderStyle = BorderStyle.FixedSingle;
            PasswordText.Dock = DockStyle.Top;
            PasswordText.Font = new Font("Microsoft Sans Serif", 11F);
            PasswordText.ForeColor = Color.FromArgb(40, 40, 40);
            PasswordText.Location = new Point(0, 68);
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
            PasswordLabel.Font = new Font("Microsoft Sans Serif", 10F);
            PasswordLabel.ForeColor = Color.FromArgb(251, 241, 199);
            PasswordLabel.Location = new Point(0, 48);
            PasswordLabel.Margin = new Padding(4, 0, 4, 0);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(83, 20);
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
            UserNameText.Location = new Point(0, 20);
            UserNameText.Margin = new Padding(4, 5, 4, 5);
            UserNameText.Name = "UserNameText";
            UserNameText.Size = new Size(400, 28);
            UserNameText.TabIndex = 1;
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Dock = DockStyle.Top;
            UserNameLabel.Font = new Font("Microsoft Sans Serif", 10F);
            UserNameLabel.ForeColor = Color.FromArgb(251, 241, 199);
            UserNameLabel.Location = new Point(0, 0);
            UserNameLabel.Margin = new Padding(4, 0, 4, 0);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(86, 20);
            UserNameLabel.TabIndex = 0;
            UserNameLabel.Text = "Username";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(GenderCombo);
            panel1.Controls.Add(GenderLabel);
            panel1.Controls.Add(CityText);
            panel1.Controls.Add(CityLabel);
            panel1.Controls.Add(CountryText);
            panel1.Controls.Add(CountryLabel);
            panel1.Controls.Add(LastNameText);
            panel1.Controls.Add(LastNameLabel);
            panel1.Controls.Add(FirstNameText);
            panel1.Controls.Add(FirstNameLabel);
            panel1.Controls.Add(EmailText);
            panel1.Controls.Add(EmailLabel);
            panel1.Controls.Add(PasswordText);
            panel1.Controls.Add(PasswordLabel);
            panel1.Controls.Add(UserNameText);
            panel1.Controls.Add(UserNameLabel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 561);
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 411);
            panel3.Name = "panel3";
            panel3.Size = new Size(400, 150);
            panel3.TabIndex = 5;
            panel3.Visible = false;
            // 
            // GenderCombo
            // 
            GenderCombo.BackColor = Color.FromArgb(235, 219, 178);
            GenderCombo.Dock = DockStyle.Top;
            GenderCombo.FlatStyle = FlatStyle.Flat;
            GenderCombo.Font = new Font("Microsoft Sans Serif", 11F);
            GenderCombo.ForeColor = Color.FromArgb(40, 40, 40);
            GenderCombo.FormattingEnabled = true;
            GenderCombo.Items.AddRange(new object[] { "Male", "Female", "Chad", "Other" });
            GenderCombo.Location = new Point(0, 356);
            GenderCombo.Margin = new Padding(4, 5, 4, 5);
            GenderCombo.Name = "GenderCombo";
            GenderCombo.Size = new Size(400, 30);
            GenderCombo.TabIndex = 4;
            // 
            // GenderLabel
            // 
            GenderLabel.AutoSize = true;
            GenderLabel.Dock = DockStyle.Top;
            GenderLabel.Font = new Font("Microsoft Sans Serif", 10F);
            GenderLabel.ForeColor = Color.FromArgb(251, 241, 199);
            GenderLabel.Location = new Point(0, 336);
            GenderLabel.Margin = new Padding(4, 0, 4, 0);
            GenderLabel.Name = "GenderLabel";
            GenderLabel.Size = new Size(64, 20);
            GenderLabel.TabIndex = 14;
            GenderLabel.Text = "Gender";
            // 
            // CityText
            // 
            CityText.BackColor = Color.FromArgb(235, 219, 178);
            CityText.BorderStyle = BorderStyle.FixedSingle;
            CityText.Dock = DockStyle.Top;
            CityText.Font = new Font("Microsoft Sans Serif", 11F);
            CityText.ForeColor = Color.FromArgb(40, 40, 40);
            CityText.Location = new Point(0, 308);
            CityText.Margin = new Padding(4, 5, 4, 5);
            CityText.Name = "CityText";
            CityText.Size = new Size(400, 28);
            CityText.TabIndex = 13;
            // 
            // CityLabel
            // 
            CityLabel.AutoSize = true;
            CityLabel.Dock = DockStyle.Top;
            CityLabel.Font = new Font("Microsoft Sans Serif", 10F);
            CityLabel.ForeColor = Color.FromArgb(251, 241, 199);
            CityLabel.Location = new Point(0, 288);
            CityLabel.Margin = new Padding(4, 0, 4, 0);
            CityLabel.Name = "CityLabel";
            CityLabel.Size = new Size(38, 20);
            CityLabel.TabIndex = 12;
            CityLabel.Text = "City";
            // 
            // CountryText
            // 
            CountryText.BackColor = Color.FromArgb(235, 219, 178);
            CountryText.BorderStyle = BorderStyle.FixedSingle;
            CountryText.Dock = DockStyle.Top;
            CountryText.Font = new Font("Microsoft Sans Serif", 11F);
            CountryText.ForeColor = Color.FromArgb(40, 40, 40);
            CountryText.Location = new Point(0, 260);
            CountryText.Margin = new Padding(4, 5, 4, 5);
            CountryText.Name = "CountryText";
            CountryText.Size = new Size(400, 28);
            CountryText.TabIndex = 11;
            // 
            // CountryLabel
            // 
            CountryLabel.AutoSize = true;
            CountryLabel.Dock = DockStyle.Top;
            CountryLabel.Font = new Font("Microsoft Sans Serif", 10F);
            CountryLabel.ForeColor = Color.FromArgb(251, 241, 199);
            CountryLabel.Location = new Point(0, 240);
            CountryLabel.Margin = new Padding(4, 0, 4, 0);
            CountryLabel.Name = "CountryLabel";
            CountryLabel.Size = new Size(67, 20);
            CountryLabel.TabIndex = 10;
            CountryLabel.Text = "Country";
            // 
            // LastNameText
            // 
            LastNameText.BackColor = Color.FromArgb(235, 219, 178);
            LastNameText.BorderStyle = BorderStyle.FixedSingle;
            LastNameText.Dock = DockStyle.Top;
            LastNameText.Font = new Font("Microsoft Sans Serif", 11F);
            LastNameText.ForeColor = Color.FromArgb(40, 40, 40);
            LastNameText.Location = new Point(0, 212);
            LastNameText.Margin = new Padding(4, 5, 4, 5);
            LastNameText.Name = "LastNameText";
            LastNameText.Size = new Size(400, 28);
            LastNameText.TabIndex = 9;
            // 
            // LastNameLabel
            // 
            LastNameLabel.AutoSize = true;
            LastNameLabel.Dock = DockStyle.Top;
            LastNameLabel.Font = new Font("Microsoft Sans Serif", 10F);
            LastNameLabel.ForeColor = Color.FromArgb(251, 241, 199);
            LastNameLabel.Location = new Point(0, 192);
            LastNameLabel.Margin = new Padding(4, 0, 4, 0);
            LastNameLabel.Name = "LastNameLabel";
            LastNameLabel.Size = new Size(91, 20);
            LastNameLabel.TabIndex = 8;
            LastNameLabel.Text = "Last Name";
            // 
            // FirstNameText
            // 
            FirstNameText.BackColor = Color.FromArgb(235, 219, 178);
            FirstNameText.BorderStyle = BorderStyle.FixedSingle;
            FirstNameText.Dock = DockStyle.Top;
            FirstNameText.Font = new Font("Microsoft Sans Serif", 11F);
            FirstNameText.ForeColor = Color.FromArgb(40, 40, 40);
            FirstNameText.Location = new Point(0, 164);
            FirstNameText.Margin = new Padding(4, 5, 4, 5);
            FirstNameText.Name = "FirstNameText";
            FirstNameText.Size = new Size(400, 28);
            FirstNameText.TabIndex = 7;
            // 
            // FirstNameLabel
            // 
            FirstNameLabel.AutoSize = true;
            FirstNameLabel.Dock = DockStyle.Top;
            FirstNameLabel.Font = new Font("Microsoft Sans Serif", 10F);
            FirstNameLabel.ForeColor = Color.FromArgb(251, 241, 199);
            FirstNameLabel.Location = new Point(0, 144);
            FirstNameLabel.Margin = new Padding(4, 0, 4, 0);
            FirstNameLabel.Name = "FirstNameLabel";
            FirstNameLabel.Size = new Size(92, 20);
            FirstNameLabel.TabIndex = 6;
            FirstNameLabel.Text = "First Name";
            // 
            // EmailText
            // 
            EmailText.BackColor = Color.FromArgb(235, 219, 178);
            EmailText.BorderStyle = BorderStyle.FixedSingle;
            EmailText.Dock = DockStyle.Top;
            EmailText.Font = new Font("Microsoft Sans Serif", 11F);
            EmailText.ForeColor = Color.FromArgb(40, 40, 40);
            EmailText.Location = new Point(0, 116);
            EmailText.Margin = new Padding(4, 5, 4, 5);
            EmailText.Name = "EmailText";
            EmailText.Size = new Size(400, 28);
            EmailText.TabIndex = 5;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Dock = DockStyle.Top;
            EmailLabel.Font = new Font("Microsoft Sans Serif", 10F);
            EmailLabel.ForeColor = Color.FromArgb(251, 241, 199);
            EmailLabel.Location = new Point(0, 96);
            EmailLabel.Margin = new Padding(4, 0, 4, 0);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(51, 20);
            EmailLabel.TabIndex = 4;
            EmailLabel.Text = "Email";
            // 
            // RegisterButton
            // 
            RegisterButton.BackColor = Color.FromArgb(211, 134, 155);
            RegisterButton.Dock = DockStyle.Bottom;
            RegisterButton.FlatStyle = FlatStyle.Flat;
            RegisterButton.Font = new Font("Microsoft Sans Serif", 12F);
            RegisterButton.ForeColor = Color.FromArgb(40, 40, 40);
            RegisterButton.Location = new Point(0, 40);
            RegisterButton.Margin = new Padding(4, 5, 4, 5);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(400, 69);
            RegisterButton.TabIndex = 2;
            RegisterButton.Text = "Register";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // LoginLink
            // 
            LoginLink.ActiveLinkColor = Color.FromArgb(211, 134, 155);
            LoginLink.AutoSize = true;
            LoginLink.Dock = DockStyle.Top;
            LoginLink.Font = new Font("Microsoft Sans Serif", 10F);
            LoginLink.LinkColor = Color.FromArgb(131, 165, 152);
            LoginLink.Location = new Point(0, 0);
            LoginLink.Margin = new Padding(4, 0, 4, 0);
            LoginLink.Name = "LoginLink";
            LoginLink.Size = new Size(204, 20);
            LoginLink.TabIndex = 3;
            LoginLink.TabStop = true;
            LoginLink.Text = "I already have an account!";
            LoginLink.LinkClicked += LoginLink_LinkClicked;
            // 
            // panel2
            // 
            panel2.Controls.Add(LoginLink);
            panel2.Controls.Add(RegisterButton);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 566);
            panel2.Name = "panel2";
            panel2.Size = new Size(400, 109);
            panel2.TabIndex = 4;
            // 
            // RegisterView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "RegisterView";
            Size = new Size(400, 675);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
		private GruvboxTextBox PasswordText;
		private GruvboxLabel PasswordLabel;
		private GruvboxTextBox UserNameText;
		private GruvboxLabel UserNameLabel;
		private GruvboxTextBox EmailText;
		private GruvboxLabel EmailLabel;
		private GruvboxButton RegisterButton;
		private GruvboxLabel GenderLabel;
		private GruvboxTextBox CityText;
		private GruvboxLabel CityLabel;
		private GruvboxTextBox CountryText;
		private GruvboxLabel CountryLabel;
		private GruvboxTextBox LastNameText;
		private GruvboxLabel LastNameLabel;
		private GruvboxTextBox FirstNameText;
		private GruvboxLabel FirstNameLabel;
		private GruvboxLink LoginLink;
		private GruvboxComboBox GenderCombo;
        private CaptchaComponent CaptchaComponent;
        private Panel panel2;
        private Panel panel3;
    }
}
