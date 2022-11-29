using PuzzleCraft_v3.Classes;
using System.Drawing.Drawing2D;

namespace PuzzleCraft_v3.GUI
{
    public partial class Token : UserControl
    {
        private Bitmap Image;
        private ProgressBar HealthBar;
        private PictureBox PicBox;
        private Point StartPoint;
        private static Random rnd = new Random();

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
                if (value + this.Width > Main.MainForm?.ClientSize.Width)
                    startX = (int)Main.MainForm?.ClientSize.Width - this.Width;
                else
                    startX = value;
            }
        }
        public double LocY
        {
            get { return startY; }
            set
            {
                if (value + this.Height > Main.MainForm?.ClientSize.Height)
                    startY = (int)Main.MainForm?.ClientSize.Height - this.Height;
                else
                    startY = value;
            }
        }

        public Token(BaseCharacter character)
        {
            InitializeComponent();
            //Transparent background breaks the game?
            StartPoint = SpawnLocation(character.TokenSize);
            startX = StartPoint.X;
            startY = StartPoint.Y;
            Image = character.Bitmap;
            this.Top = (int)startY;
            this.Left = (int)startX;
            this.Size = character.TokenSize;
            SetUpPicture(character.Bitmap, character.Health);
            Main.MainForm?.Controls.Add(this);
        }

        public static Point SpawnLocation(Size newMonster)
        {
            Point spawnPoint = new(rnd.Next(0, Main.MainForm.ClientSize.Width - newMonster.Width),
                                        rnd.Next(0, Main.MainForm.ClientSize.Height - newMonster.Height));
            return spawnPoint;
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
            PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PicBox.Image = pic;
            PicBox.Size = new Size((int)Math.Round(this.Size.Width / 1.05), (int)Math.Round(this.Size.Height / 1.05));
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
            Image tmpImage;
            tmpImage = RotateImage(Image, Angle + 90);
            PicBox.Image = tmpImage;
        }
    }
}