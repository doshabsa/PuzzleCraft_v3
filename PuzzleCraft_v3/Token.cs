using PuzzleCraft_v3.Classes;
using System.Drawing.Drawing2D;

namespace PuzzleCraft_v3
{
    public partial class Token : UserControl
    {
        private Bitmap Image;
        private ProgressBar HealthBar;
        private PictureBox PicBox;

        private bool RotationFlag;
        private double startX;
        private double startY;
        private float Angle;
        public double StepX { get; set; }
        public double StepY { get; set; }
        public double LocX
        {
            get { return startX; }
            set
            {
                if (value + this.Width > BaseCharacter.MainForm?.ClientSize.Width)
                    startX = (int)BaseCharacter.MainForm?.ClientSize.Width - this.Width;
                else
                    startX = value;
            }
        }
        public double LocY
        {
            get { return startY; }
            set
            {
                if (value + this.Height > BaseCharacter.MainForm?.ClientSize.Height)
                    startY = (int)BaseCharacter.MainForm?.ClientSize.Height - this.Height;
                else
                    startY = value;
            }
        }

        public Token(Bitmap pic, Size newSize, Point loc, int hp, bool rotationFlag)
        {
            InitializeComponent();
            RotationFlag = rotationFlag;
            startX = loc.X;
            startY = loc.Y;
            this.Top = loc.Y;
            this.Left = loc.X;
            this.Size = newSize;
            Image = pic;
            SetUpPicture(Image, hp);
            BaseCharacter.MainForm?.Controls.Add(this);
        }

        public void UpdateTokenHP(int damage)
        {
            if (damage > HealthBar.Value)
                HealthBar.Value = 0;
            else
                HealthBar.Value -= damage;
        }

        public void UpdatePictureDirection(BaseCharacter tmp, float angle)
        {
            Angle = angle;
            this.Invalidate(false);
        }

        private void SetUpPicture(Bitmap pic, int hp)
        {
            PicBox = new();
            PicBox.Image = pic;
            PicBox.Size = new Size((int)Math.Round(this.Size.Width / 1.05), (int)Math.Round(this.Size.Height / 1.05));
            PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PicBox.Location = new Point(this.Width / 2 - PicBox.Width / 2, this.Height / 2 - PicBox.Height / 2);
            this.Controls.Add(PicBox);

            HealthBar = new ProgressBar();
            HealthBar.Height = 3;
            HealthBar.Maximum = hp;
            HealthBar.Value = hp;
            this.Controls.Add(HealthBar);
            HealthBar.BringToFront();
        }

        private static Image RotateImage(Image img, float rotationAngle)
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

        private void Token_Paint(object sender, PaintEventArgs e)
        {
            if (RotationFlag)
            {
                Image tmpImage;
                tmpImage = RotateImage(Image, Angle + 90); //Rotates 90 because images facing up
                PicBox.Image = tmpImage;
            }
            else
            {
                PicBox.Image = Image;
            }
        }
    }
}
