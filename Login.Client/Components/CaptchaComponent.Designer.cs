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
            ((System.ComponentModel.ISupportInitialize)captchaPictureBox).BeginInit();
            SuspendLayout();
            // 
            // captchaPictureBox
            // 
            captchaPictureBox.Dock = DockStyle.Left;
            captchaPictureBox.Location = new Point(0, 0);
            captchaPictureBox.Name = "captchaPictureBox";
            captchaPictureBox.Size = new Size(150, 150);
            captchaPictureBox.TabIndex = 0;
            captchaPictureBox.TabStop = false;
            // 
            // CaptchaComponent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(captchaPictureBox);
            Name = "CaptchaComponent";
            Size = new Size(400, 150);
            Load += CaptchaComponent_Load;
            ((System.ComponentModel.ISupportInitialize)captchaPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox captchaPictureBox;
    }
}
