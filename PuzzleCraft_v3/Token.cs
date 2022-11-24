using PuzzleCraft_v3.Classes;
using System.Drawing.Drawing2D;

namespace PuzzleCraft_v3
{
    public partial class Token : UserControl
    {
        public double StepX { get; set; }
        public double StepY { get; set; }
        public double LocX { get; set; }
        public double LocY { get; set; }

        private Bitmap Bitmap;
        public PictureBox PicBox;
        private ProgressBar ProgressBar;
        public float Angle;

        public Token(Bitmap pic, Size newSize, Point loc, int hp)
        {
            InitializeComponent();
            this.BackColor = Color.Black;
            LocX = loc.X;
            LocY = loc.Y;
            this.Top = loc.Y;
            this.Left = loc.X;
            this.Size = newSize;
            Bitmap = pic;
            SetUpPicture(Bitmap, hp);
            BaseChar.MainForm?.Controls.Add(this);
        }

        private void SetUpPicture(Bitmap pic, int hp)
        {
            PicBox = new();
            PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PicBox.Image = pic;
            PicBox.Size = new Size((int)Math.Round(this.Size.Width/1.05), (int)Math.Round(this.Size.Height / 1.05));
            PicBox.Location = new Point(this.Width/2 - PicBox.Width/2, this.Height/2 - PicBox.Height/2);
            this.Controls.Add(PicBox);

            ProgressBar = new ProgressBar();
            ProgressBar.Height = 3;
            ProgressBar.Maximum = hp;
            ProgressBar.Value = hp;
            this.Controls.Add(ProgressBar);
            ProgressBar.BringToFront();
        }

        public void UpdateTokenHP(int damage)
        {
            ProgressBar.Value -= damage;
        }

        public static Image RotateImage(Image img, float rotationAngle)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(img, new Point(0, 0));
            gfx.Dispose();
            return bmp;
        }

        public void UpdatePictureDirection(BaseChar tmp, float angle)
        {
            Angle = angle;
            this.Invalidate(false);
        }

        private void Token_Paint(object sender, PaintEventArgs e)
        {
            Image tmpImage;
            tmpImage = RotateImage(Bitmap, Angle+90);
            PicBox.Image = tmpImage;
        }
    }
}
