namespace Login.Client
{
	partial class ConnectView
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
            IPLabel = new GruvboxLabel();
            IPText = new GruvboxTextBox();
            PortText = new GruvboxTextBox();
            PortLabel = new GruvboxLabel();
            ConnectButton = new GruvboxButton();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.Dock = DockStyle.Top;
            IPLabel.Font = new Font("Microsoft Sans Serif", 12F);
            IPLabel.ForeColor = Color.FromArgb(251, 241, 199);
            IPLabel.Location = new Point(0, 0);
            IPLabel.Margin = new Padding(5, 0, 5, 0);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(30, 25);
            IPLabel.TabIndex = 0;
            IPLabel.Text = "IP";
            // 
            // IPText
            // 
            IPText.BackColor = Color.FromArgb(235, 219, 178);
            IPText.BorderStyle = BorderStyle.FixedSingle;
            IPText.Dock = DockStyle.Top;
            IPText.Font = new Font("Microsoft Sans Serif", 12F);
            IPText.ForeColor = Color.FromArgb(40, 40, 40);
            IPText.Location = new Point(0, 25);
            IPText.Margin = new Padding(5);
            IPText.Name = "IPText";
            IPText.Size = new Size(400, 30);
            IPText.TabIndex = 1;
            // 
            // PortText
            // 
            PortText.BackColor = Color.FromArgb(235, 219, 178);
            PortText.BorderStyle = BorderStyle.FixedSingle;
            PortText.Dock = DockStyle.Top;
            PortText.Font = new Font("Microsoft Sans Serif", 12F);
            PortText.ForeColor = Color.FromArgb(40, 40, 40);
            PortText.Location = new Point(0, 80);
            PortText.Margin = new Padding(5);
            PortText.Name = "PortText";
            PortText.Size = new Size(400, 30);
            PortText.TabIndex = 4;
            // 
            // PortLabel
            // 
            PortLabel.AutoSize = true;
            PortLabel.Dock = DockStyle.Top;
            PortLabel.Font = new Font("Microsoft Sans Serif", 12F);
            PortLabel.ForeColor = Color.FromArgb(251, 241, 199);
            PortLabel.Location = new Point(0, 55);
            PortLabel.Margin = new Padding(5, 0, 5, 0);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(47, 25);
            PortLabel.TabIndex = 3;
            PortLabel.Text = "Port";
            // 
            // ConnectButton
            // 
            ConnectButton.BackColor = Color.FromArgb(211, 134, 155);
            ConnectButton.Dock = DockStyle.Bottom;
            ConnectButton.FlatStyle = FlatStyle.Flat;
            ConnectButton.Font = new Font("Microsoft Sans Serif", 11F);
            ConnectButton.ForeColor = Color.FromArgb(40, 40, 40);
            ConnectButton.Location = new Point(0, 158);
            ConnectButton.Margin = new Padding(5);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(400, 45);
            ConnectButton.TabIndex = 5;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(PortText);
            panel1.Controls.Add(PortLabel);
            panel1.Controls.Add(IPText);
            panel1.Controls.Add(IPLabel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(13, 15, 13, 15);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 141);
            panel1.TabIndex = 6;
            // 
            // ConnectView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(panel1);
            Controls.Add(ConnectButton);
            Margin = new Padding(5);
            Name = "ConnectView";
            Size = new Size(400, 203);
            Load += ConnectControl_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
		private GruvboxLabel IPLabel;
		private GruvboxTextBox IPText;
		private GruvboxTextBox PortText;
		private GruvboxLabel PortLabel;
		private GruvboxButton ConnectButton;
	}
}
