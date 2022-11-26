using PuzzleCraft_v3.Classes;
using System.Drawing.Drawing2D;

namespace PuzzleCraft_v3
{
    public partial class Token : UserControl
    {
        #region Properties
        private Bitmap? _Image;
        private ProgressBar? _HealthBar;
        private PictureBox _PicBox;
        private static Size _ItemSize = new Size(45,45);

        private bool _RotationFlag;
        private bool _isMonster;
        private double _startX;
        private double _startY;
        private float _Angle;
        #endregion

        #region Public Properties
        public double _StepX { get; set; }
        public double _StepY { get; set; }

        public double LocX
        {
            get { return _startX; }
            set
            {
                if (!_isMonster)
                {
                    if (value + this.Width > Main.MainForm?.ClientSize.Width)
                        _startX = (int)Main.MainForm?.ClientSize.Width - this.Width;
                }
                else
                    _startX = value;
            }
        }
        public double LocY
        {
            get { return _startY; }
            set
            {
                if (!_isMonster)
                {
                    if (value + this.Height > Main.MainForm?.ClientSize.Height)
                        _startY = (int)Main.MainForm?.ClientSize.Height - this.Height;
                }
                else
                    _startY = value;
            }
        }
        #endregion

        #region Constructors
        public Token(Bitmap pic, Size newSize, Point loc, int hp)  //For Player
        {
            InitializeComponent();
            _RotationFlag = true;
            _isMonster = false;
            _startX = loc.X;
            _startY = loc.Y;
            this.Top = loc.Y;
            this.Left = loc.X;
            this.Size = newSize;
            _Image = pic;
            SetUpPicture(_Image, hp);
            Main.MainForm?.Controls.Add(this);
        }

        public Token(string name, Bitmap pic, Size newSize, Point loc, int hp, bool rotationFlag) //For Monster
        {
            InitializeComponent();
            _RotationFlag = rotationFlag;
            _isMonster = true;
            _startX = loc.X;
            _startY = loc.Y;
            this.Top = loc.Y;
            this.Left = loc.X;
            DumbMonsterMove();
            this.Size = newSize;
            _Image = pic;
            SetUpPicture(_Image, hp);
            Main.MainForm?.Controls.Add(this);
        }

        public Token(string name, Bitmap? pic, Point loc)  //For Item
        {
            InitializeComponent();
            _RotationFlag = false;
            _isMonster = false;
            _startX = loc.X;
            _startY = loc.Y;
            this.Top = loc.Y;
            this.Left = loc.X;
            this.Size = _ItemSize;
            _Image = pic;
            int hp = 0;
            SetUpPicture(_Image, hp);
            Main.MainForm?.Controls.Add(this);
        }
        #endregion

        public void UpdateTokenHP(BaseCharacter character)
        {
                _HealthBar.Value = character.Health;
        }

        public void UpdatePictureDirection(BaseCharacter tmp, float angle)
        {
            _Angle = angle;
            this.Invalidate(false);
        }

        #region Paint Events
        private void SetUpPicture(Bitmap? pic, int hp)
        {
            _PicBox = new();
            _PicBox.Image = pic;
            _PicBox.Size = new Size((int)Math.Round(this.Size.Width / 1.05), (int)Math.Round(this.Size.Height / 1.05));
            _PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _PicBox.Location = new Point(this.Width / 2 - _PicBox.Width / 2, this.Height / 2 - _PicBox.Height / 2);
            this.Controls.Add(_PicBox);

            if (hp != 0)
            {
                _HealthBar = new ProgressBar();
                _HealthBar.Height = 3;
                _HealthBar.Maximum = hp;
                _HealthBar.Value = hp;
                this.Controls.Add(_HealthBar);
                _HealthBar.BringToFront();
            }
        }

        private static Image RotateImage(Image? img, float rotationAngle)
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
            if (_RotationFlag)
            {
                Image tmpImage;
                tmpImage = RotateImage(_Image, _Angle + 90); //Rotates 90 because images facing up
                _PicBox.Image = tmpImage;
            }
            else
            {
                _PicBox.Image = _Image;
            }
        }
        #endregion

        #region Monster Events
        private void DumbMonsterMove()
        {
            if (this.Left < Main.MainForm.ClientSize.Width / 2) { _StepX = 1; }
            if (this.Left > Main.MainForm.ClientSize.Width / 2) { _StepX = -1; }
            if (this.Top < Main.MainForm.ClientSize.Height / 2) { _StepY = 1; }
            if (this.Left > Main.MainForm.ClientSize.Width / 2) { _StepX = -1; }
        }
        #endregion
    }
}
