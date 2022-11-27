using PuzzleCraft_v3.Classes;
using System.Drawing.Drawing2D;

namespace PuzzleCraft_v3.GUI.Token
{
    public class ItemToken
    {

        /*
        Issues:
           - if token is made with a transparent background, things break (ticks, labels, monster tokens, etc.)
           - if background is light color, token images WILL artifact. might still do this with darker bag color, not bothering with testing that
        */

        #region Properties
        protected Bitmap? _Image;
        protected Panel _Panel;
        protected PictureBox _PicBox;
        protected ProgressBar? _HealthBar;
        protected static Size _ItemSize = new Size(45, 45);
        protected bool _RotationFlag;
        protected bool _isMonster;
        protected double _startX;
        protected double _startY;
        protected float _Angle;
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
                    if (value + _ItemSize.Width > Main.MainForm?.ClientSize.Width)
                        _startX = (int)Main.MainForm?.ClientSize.Width - _ItemSize.Width;
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
                    if (value + _ItemSize.Height > Main.MainForm?.ClientSize.Height)
                        _startY = (int)Main.MainForm?.ClientSize.Height - _ItemSize.Height;
                }
                else
                    _startY = value;
            }
        }
        public Bitmap Image { get { return _Image; } }
        #endregion

        #region Constructors
        public ItemToken(Bitmap pic, Size newSize, Point loc, int hp)  //For Player
        {
            _RotationFlag = true;
            _isMonster = false;
            _startX = loc.X;
            _startY = loc.Y;
            _PicBox.Top = loc.Y;
            _PicBox.Left = loc.X;
            _PicBox.Size = newSize;
            _Image = pic;
            SetUpPicture(_Image, hp);
            Main.MainForm?.Controls.Add(_PicBox);
        }

        public ItemToken(string name, Bitmap pic, Size newSize, Point loc, int hp, bool rotationFlag) //For Monster
        {
            _RotationFlag = rotationFlag;
            _isMonster = true;
            _startX = loc.X;
            _startY = loc.Y;
            _PicBox.Top = loc.Y;
            _PicBox.Left = loc.X;
            DumbMonsterMove();
            _PicBox.Size = newSize;
            _Image = pic;
            SetUpPicture(_Image, hp);
            Main.MainForm?.Controls.Add(_PicBox);
        }

        public ItemToken(string name, Bitmap? pic, Point loc)  //For Item
        {
            _RotationFlag = false;
            _isMonster = false;
            _startX = loc.X;
            _startY = loc.Y;
            _PicBox.Top = loc.Y;
            _PicBox.Left = loc.X;
            _PicBox.Size = _ItemSize;
            _Image = pic;
            int hp = 0;
            SetUpPicture(_Image, hp);
            Main.MainForm?.Controls.Add(_PicBox);
        }
        #endregion

        public void UpdateTokenHP(BaseCharacter character)
        {
            _HealthBar.Value = character.Health;
        }

        public void UpdatePictureDirection(BaseCharacter tmp, float angle)
        {
            _Angle = angle;
            _PicBox.Invalidate(false);
        }

        #region Paint Events
        private void SetUpPicture(Bitmap? pic, int hp)
        {
            _PicBox = new();
            _PicBox.Image = pic;
            _PicBox.Size = new Size((int)Math.Round(_PicBox.Size.Width / 1.05), (int)Math.Round(this.Size.Height / 1.05));
            _PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _PicBox.Location = new Point(_PicBox.Width / 2 - _PicBox.Width / 2, _PicBox.Height / 2 - _PicBox.Height / 2);
            Main.MainForm?.Controls.Add(_PicBox);

            if (hp != 0)
            {
                _HealthBar = new ProgressBar();
                _HealthBar.Height = 3;
                _HealthBar.Maximum = hp;
                _HealthBar.Value = hp;
                Main.MainForm?.Controls.Add(_HealthBar);
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
            if (_PicBox.Left < Main.MainForm.ClientSize.Width / 2) { _StepX = 1; }
            if (_PicBox.Left > Main.MainForm.ClientSize.Width / 2) { _StepX = -1; }
            if (_PicBox.Top < Main.MainForm.ClientSize.Height / 2) { _StepY = 1; }
            if (_PicBox.Left > Main.MainForm.ClientSize.Width / 2) { _StepX = -1; }
        }
        #endregion
    }
}