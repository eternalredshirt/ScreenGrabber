namespace ScreenGrabber
{
    partial class MainWindow
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
            btnClose = new Button();
            pnlDrag = new Panel();
            dialogSave = new SaveFileDialog();
            btnSave = new Button();
            SuspendLayout();
            // 
            // btnGrab
            // 
            btnGrab.Location = new Point(135, 140);
            btnGrab.Margin = new Padding(0);
            btnGrab.Name = "btnGrab";
            btnGrab.Size = new Size(50, 25);
            btnGrab.TabIndex = 0;
            btnGrab.Text = "Grab";
            btnGrab.UseVisualStyleBackColor = true;
            btnGrab.Click += btnGrab_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.None;
            btnClose.BackColor = SystemColors.Highlight;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(295, 0);
            btnClose.Margin = new Padding(0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(25, 25);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // pnlDrag
            // 
            pnlDrag.Cursor = Cursors.Hand;
            pnlDrag.Location = new Point(0, 0);
            pnlDrag.Margin = new Padding(0);
            pnlDrag.Name = "pnlDrag";
            pnlDrag.Size = new Size(295, 25);
            pnlDrag.TabIndex = 2;
            // 
            // dialogSave
            // 
            dialogSave.FileOk += SaveFileDialog1_FileOk;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(135, 140);
            btnSave.Margin = new Padding(0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(50, 25);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(320, 180);
            Controls.Add(btnSave);
            Controls.Add(pnlDrag);
            Controls.Add(btnClose);
            Controls.Add(btnGrab);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(1);
            Name = "MainWindow";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnGrab;
        private Button btnClose;
        private Panel pnlDrag;
        private SaveFileDialog dialogSave;
        private Button btnSave;
    }
}
