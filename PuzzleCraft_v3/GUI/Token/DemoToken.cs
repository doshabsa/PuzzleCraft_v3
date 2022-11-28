using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.Classes.Monsters;
using PuzzleCraft_v3.GUI;
using PuzzleCraft_v3.GUI.Token;
using static PuzzleCraft_v3.Classes.Player;

namespace PuzzleCraft_v3.Classes
{
    public partial class DemoToken : UserControl
    {
        /*
         Issues:
            - if token is made with a transparent background, things break (ticks, labels, monster tokens, etc.)
            - if background is light color, token images WILL artifact. might still do this with darker bag color, not bothering with testing that
         */

        #region Properties
        public static List<DemoToken> TokenList;
        protected BaseCharacter _Character;
        protected Panel _Panel;
        protected PictureBox _PicBox;
        protected ProgressBar? _HealthBar;
        protected static Random _rnd;
        private Point _StartPoint;
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
                if (_Character is Player)
                {
                    if (value + Size.Width > Main.MainForm?.ClientSize.Width)
                        _startX = (int)Main.MainForm?.ClientSize.Width - Size.Width;
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
                if (_Character is Player)
                {
                    if (value + Size.Height > Main.MainForm?.ClientSize.Height)
                        _startY = (int)Main.MainForm?.ClientSize.Height - Size.Height;
                }
                else
                    _startY = value;
            }
        }
        public Panel Panel { get { return _Panel; } }
        public Size Size { get { return _Character.Size; } }
        protected Bitmap Image { get { return _Character.Image; } }
        protected bool CanMove { get { return _Character.CanMove; } }
        protected bool CanRotate { get { return _Character.CanRotate; } }
        #endregion

        #region Constructors
        static DemoToken()
        {
            _rnd = new();
            TokenList = new();
        }

        public DemoToken(BaseCharacter character)
        {
            _Character = character;
            _StartPoint = RandomPoint();
            SetUpDynamicControls();
            TokenList.Add(this);
            Main.MainForm?.Controls.Add(_Panel);
        }
        private Point RandomPoint()
        {
            Point tmp = new(_rnd.Next(0, Main.MainForm.ClientSize.Width - Size.Width),
                           _rnd.Next(0, Main.MainForm.ClientSize.Height - Size.Height));
            _startX = _StartPoint.X;
            _startY = _StartPoint.Y;
            return tmp;
        }
        #endregion

        #region Dynamic Controls
        private void SetUpDynamicControls()
        {
            _Panel = new();
            _Panel.Location = _StartPoint;
            _Panel.BackColor = Color.Transparent;
            _Panel.Size = Size;
            Main.MainForm?.Controls.Add(_Panel);

            _PicBox = new();
            _PicBox.Image = _Character.Image;
            _PicBox.Dock = DockStyle.Fill;
            _PicBox.BackColor = Color.Transparent;
            _PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //_PicBox.Paint += _PicBox_Paint;
            _PicBox.Location = new Point((int)_startX, (int)_startY);
            _Panel.Controls.Add(_PicBox);

            if (_Character is Monster || _Character is Player)
            {
                _HealthBar = new ProgressBar();
                _HealthBar.Height = 3;
                _HealthBar.Dock = DockStyle.Top;
                _HealthBar.Maximum = _Character.Health;
                _HealthBar.Value = _Character.Health;
                _Panel.Controls.Add(_HealthBar);
                _HealthBar.BringToFront();
            }
        }

        public void UpdateTokenHP(BaseCharacter character)
        {
            _HealthBar.Value = character.Health;
        }
        #endregion

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
            if (CanMove)
            {
                Image tmpImage;
                tmpImage = RotateImage(Image, _Angle + 90); //Rotates 90 because images facing up
                _PicBox.Image = tmpImage;
            }
            else
            {
                _PicBox.Image = Image;
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