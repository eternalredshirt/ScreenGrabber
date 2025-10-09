namespace ScreenGrabber
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGrab = new Button();
            SuspendLayout();
            // 
            // btnGrab
            // 
            btnGrab.Location = new Point(0, 0);
            btnGrab.Name = "btnGrab";
            btnGrab.Size = new Size(188, 58);
            btnGrab.TabIndex = 0;
            btnGrab.Text = "Grab";
            btnGrab.UseVisualStyleBackColor = true;
            btnGrab.Click += btnGrab_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGrab);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnGrab;
    }
}
