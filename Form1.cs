using System.Diagnostics;
using System.Drawing.Text;
using System.Threading.Tasks;

namespace ScreenGrabber
{
    public partial class MainWindow : Form
    {
        private bool pnlDragIsDragging = false;
        private Point lastCursorPos;

        public MainWindow()
        {
            //TODO remove debug members
            InitializeComponent();

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
            //pnlDrag.Cursor = Cursors.Hand;

            pnlDrag.MouseDown += pnlDrag_MouseDown;
            pnlDrag.MouseMove += pnlDrag_Move;
            pnlDrag.MouseUp += pnlDrag_MouseUp;


            //Testing Debug
            Debug.Print("Ready to grab");

            Debug.Print(btnClose.Height.ToString() + " " + btnClose.Width.ToString());
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
            if (pnlDragIsDragging) {
                this.Left += e.X - lastCursorPos.X;
                this.Top += e.Y - lastCursorPos.Y;
            }
        }

        private void pnlDrag_MouseUp(object sender, MouseEventArgs e)
        {
            
            pnlDragIsDragging = false;
            
        }

        private async void btnGrab_Click(object sender, EventArgs e)
        {
            this.Hide();

            await Task.Delay(150);
            //TODO Hide window on capture - Done, window capture must be paused after hiding window.

            //TODO Give button relative flexible position

            /* TODO Shrink Screenshot to window size - DONE!
             * that was actually fun however the "this.size.height"
             * includes the menu bar height, cutting off the taskbar 
             * in the window*/

            //Code that runs on Grab Button click
            Rectangle rockt = Screen.PrimaryScreen.Bounds;

            Bitmap bm = new Bitmap(rockt.Width, rockt.Height);

            Graphics g = Graphics.FromImage(bm);

            g.CopyFromScreen(0, 0, 0, 0, rockt.Size);

            //Remove if not working
            Bitmap winBm = new Bitmap(this.Size.Width, this.Size.Height);

            Graphics winG = Graphics.FromImage(winBm);

            winG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            winG.DrawImage(bm, 0, 0, this.Size.Width, this.Size.Height);

            this.BackgroundImage = winBm;

            this.Show();

            Debug.Print("Capture is completed!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
