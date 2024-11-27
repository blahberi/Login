namespace Login.Client.Components
{
    partial class CaptchaComponent
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
            captchaPictureBox = new PictureBox();
            answerTextbox = new GruvboxTextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            gruvboxLabel1 = new GruvboxLabel();
            verifyButton = new GruvboxButton();
            reloadButton = new GruvboxButton();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)captchaPictureBox).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // captchaPictureBox
            // 
            captchaPictureBox.BackColor = Color.Black;
            captchaPictureBox.Dock = DockStyle.Left;
            captchaPictureBox.Location = new Point(0, 0);
            captchaPictureBox.Name = "captchaPictureBox";
            captchaPictureBox.Size = new Size(150, 150);
            captchaPictureBox.TabIndex = 0;
            captchaPictureBox.TabStop = false;
            // 
            // answerTextbox
            // 
            answerTextbox.BackColor = Color.FromArgb(235, 219, 178);
            answerTextbox.BorderStyle = BorderStyle.FixedSingle;
            answerTextbox.Dock = DockStyle.Bottom;
            answerTextbox.ForeColor = Color.FromArgb(40, 40, 40);
            answerTextbox.Location = new Point(0, 88);
            answerTextbox.Name = "answerTextbox";
            answerTextbox.Size = new Size(230, 27);
            answerTextbox.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(170, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 150);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(gruvboxLabel1);
            panel2.Controls.Add(answerTextbox);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(230, 115);
            panel2.TabIndex = 3;
            // 
            // gruvboxLabel1
            // 
            gruvboxLabel1.Dock = DockStyle.Fill;
            gruvboxLabel1.ForeColor = Color.FromArgb(251, 241, 199);
            gruvboxLabel1.Location = new Point(0, 0);
            gruvboxLabel1.Name = "gruvboxLabel1";
            gruvboxLabel1.Size = new Size(230, 88);
            gruvboxLabel1.TabIndex = 2;
            gruvboxLabel1.Text = "Verify that you are human by writing the letters you see in the image\r\n";
            gruvboxLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // verifyButton
            // 
            verifyButton.BackColor = Color.FromArgb(211, 134, 155);
            verifyButton.Dock = DockStyle.Left;
            verifyButton.FlatAppearance.BorderSize = 0;
            verifyButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 241, 199);
            verifyButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 219, 178);
            verifyButton.FlatStyle = FlatStyle.Flat;
            verifyButton.ForeColor = Color.FromArgb(40, 40, 40);
            verifyButton.Location = new Point(0, 0);
            verifyButton.Name = "verifyButton";
            verifyButton.Size = new Size(194, 30);
            verifyButton.TabIndex = 2;
            verifyButton.Text = "Verify";
            verifyButton.UseVisualStyleBackColor = false;
            verifyButton.Click += verifyButton_Click;
            // 
            // reloadButton
            // 
            reloadButton.BackColor = Color.FromArgb(211, 134, 155);
            reloadButton.Dock = DockStyle.Right;
            reloadButton.FlatAppearance.BorderSize = 0;
            reloadButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(251, 241, 199);
            reloadButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 219, 178);
            reloadButton.FlatStyle = FlatStyle.Flat;
            reloadButton.ForeColor = Color.FromArgb(40, 40, 40);
            reloadButton.Location = new Point(200, 0);
            reloadButton.Name = "reloadButton";
            reloadButton.Size = new Size(30, 30);
            reloadButton.TabIndex = 4;
            reloadButton.Text = "⟳";
            reloadButton.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(reloadButton);
            panel3.Controls.Add(verifyButton);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 120);
            panel3.Name = "panel3";
            panel3.Size = new Size(230, 30);
            panel3.TabIndex = 3;
            // 
            // CaptchaComponent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(panel1);
            Controls.Add(captchaPictureBox);
            Name = "CaptchaComponent";
            Size = new Size(400, 150);
            Load += CaptchaComponent_Load;
            ((System.ComponentModel.ISupportInitialize)captchaPictureBox).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox captchaPictureBox;
        private GruvboxTextBox answerTextbox;
        private Panel panel1;
        private Panel panel2;
        private GruvboxLabel gruvboxLabel1;
        private GruvboxButton verifyButton;
        private Panel panel3;
        private GruvboxButton reloadButton;
    }
}
