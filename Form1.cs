using System.Diagnostics;

namespace ScreenGrabber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //TODO remove debug members
            InitializeComponent();
            //Testing Debug
            Debug.Print("Ready to grab");
        }

        private void btnGrab_Click(object sender, EventArgs e)
        {
            this.Hide();
            /*TODO Hide window on capture - almost there
             * the window is hiding but the capture happens before 
             * Hide() fires. Maybe something to delay execution?*/

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
    }
}
