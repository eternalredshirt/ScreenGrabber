using System.Diagnostics;
using System.Drawing.Text;
using System.Threading.Tasks;

namespace ScreenGrabber
{
    public partial class MainWindow : Form
    {
        private bool pnlDragIsDragging = false;
        private Point lastCursorPos;
        Bitmap bm = null;

        public MainWindow()
        {
            //TODO remove debug members
            InitializeComponent();

            bm = GetBitmapScreenShot(); 

            Rectangle ScreenSize = Screen.PrimaryScreen.Bounds;

            int winHeight = ScreenSize.Height / 2;
            int winWidth = ScreenSize.Width / 2;
            int btnGrabX = (winWidth - btnGrab.Width) / 2;
            int btnGrabY = (winHeight - btnGrab.Height) - 15;
            btnClose.Size = new Size(50, 50);
            int btnCloseX = (winWidth - btnClose.Width);
            int btnCloseY = 0;
            int pnlDragHeight = 50;
            int pnlDragWidth = winWidth - 50;

            this.Opacity = .75;

            this.Size = new Size(winWidth, winHeight);

            this.StartPosition = FormStartPosition.CenterScreen;

            btnGrab.Location = new Point(btnGrabX, btnGrabY);

            btnClose.BackColor = Color.Transparent;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Size = new Size(50, 50);
            btnClose.Location = new Point(btnCloseX, btnCloseY);

            pnlDrag.Size = new Size(pnlDragWidth, pnlDragHeight);

            pnlDrag.BackColor = Color.Transparent;

            pnlDrag.MouseDown += pnlDrag_MouseDown;
            pnlDrag.MouseMove += pnlDrag_Move;
            pnlDrag.MouseUp += pnlDrag_MouseUp;

            //Testing Debug
            //Debug.Print("Ready to grab");
        }

        private void pnlDrag_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pnlDragIsDragging = true;
                lastCursorPos = new Point(e.X, e.Y);
            }
        }
        private void pnlDrag_Move(object sender, MouseEventArgs e)
        {
            if (pnlDragIsDragging)
            {
                this.Left += e.X - lastCursorPos.X;
                this.Top += e.Y - lastCursorPos.Y;
            }
        }

        private void pnlDrag_MouseUp(object sender, MouseEventArgs e)
        {
            pnlDragIsDragging = false;
        }

        private void btnGrab_Click(object sender, EventArgs e)
        {
            this.Hide();

            Thread.Sleep(150);

            //Code that runs on Grab Button click
            bm = GetBitmapScreenShot();
            //Remove if not working
            Bitmap winBm = new Bitmap(this.Size.Width, this.Size.Height);

            Graphics winG = Graphics.FromImage(winBm);

            winG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            winG.DrawImage(bm, 0, 0, this.Size.Width, this.Size.Height);

            this.BackgroundImage = winBm;

            this.Opacity = 1;

            int btnRowX = (this.Width / 2 - (btnGrab.Width + 15 + btnSave.Width));

            int btnRowY = this.Height - btnGrab.Height - 15;

            btnGrab.Location = new Point(btnRowX, btnRowY);
            btnSave.Location = new Point((btnRowX + btnGrab.Width + 15), btnRowY);
            btnSave.Show(); 

            this.Show();

            Debug.Print("Capture is completed!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private Bitmap GetBitmapScreenShot()
        {
            Rectangle screenRectangle = Screen.PrimaryScreen.Bounds;

            Bitmap bm = new Bitmap(screenRectangle.Width, screenRectangle.Height);

            Graphics g = Graphics.FromImage(bm);

            g.CopyFromScreen(0, 0, 0, 0, screenRectangle.Size);

            return bm;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dialogSave.Filter = "Bitmap| *.bmp";
            DialogResult result = dialogSave.ShowDialog();

            if (result == DialogResult.OK) {
                string filePath = dialogSave.FileName;
                bm.Save(filePath);
            }
            

        }
    }
}
