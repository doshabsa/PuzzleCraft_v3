using PuzzleCraft_v3.Classes;
using PuzzleCraft_v3.Classes.Monsters;
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
        public static List<ItemToken> TokenList;
        protected Panel _Panel;
        protected Bitmap _Image;
        protected PictureBox _PicBox;
        protected ProgressBar? _HealthBar;
        protected static Random _rnd;
        protected Size _TokenSize;
        private Point _StartPoint;
        protected bool _IsMonster = false;
        protected bool _CanMove = false;
        protected bool _CanRotate = false;
        protected double _startX;
        protected double _startY;
        protected float _Angle;
        #endregion

        static ItemToken()
        {
            _rnd = new();
            TokenList = new();
        }

        #region Public Properties
        public double _StepX { get; set; }
        public double _StepY { get; set; }
        public double LocX
        {
            get { return _startX; }
            set
            {
                if (!_IsMonster)
                {
                    if (value + _TokenSize.Width > Main.MainForm?.ClientSize.Width)
                        _startX = (int)Main.MainForm?.ClientSize.Width - _TokenSize.Width;
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
                if (!_IsMonster)
                {
                    if (value + _TokenSize.Height > Main.MainForm?.ClientSize.Height)
                        _startY = (int)Main.MainForm?.ClientSize.Height - _TokenSize.Height;
                }
                else
                    _startY = value;
            }
        }
        public Size Size { get { return _TokenSize; } }
        public Panel Panel { get { return _Panel; } }
        public Bitmap Image { get { return _Image; } }
        #endregion

        #region Constructors
        public ItemToken(BaseCharacter character)
        {
            _Image = character.Image;
            _TokenSize = character.Size;
            _CanRotate = character.CanRotate;
            if (character is Monster) 
                _IsMonster = true;
            if (character is Monster || character is Player)
            {
                _CanMove = character.CanMove;
                _CanRotate = character.CanRotate;
            }
            _StartPoint = RandomPoint();
            SetUpDynamicControls(character);
            Main.MainForm?.Controls.Add(_Panel);
        }
        #endregion

        private Point RandomPoint()
        {
            Point tmp = new(_rnd.Next(0, Main.MainForm.ClientSize.Width - _TokenSize.Width),
                           _rnd.Next(0, Main.MainForm.ClientSize.Height - _TokenSize.Height));
            _startX = _StartPoint.X;
            _startY = _StartPoint.Y;
            return tmp;
        }

        public static void TakeSteps(ItemToken token)
        {
            token.LocX += token._StepX;
            token.LocY += token._StepY;
            token._Panel.Left = (int)token.LocX;
            token._Panel.Top = (int)token.LocY;
        }

        public void UpdateTokenHP(BaseCharacter character)
        {
            _HealthBar.Value = character.Health;
        }

        public void UpdatePictureDirection(BaseCharacter tmp, float angle)
        {
            _Angle = angle;
            _PicBox.Invalidate(false);
        }
        #region Dynamic Controls
        private void SetUpDynamicControls(BaseCharacter character)
        {
            _Panel = new();
            _Panel.Location = _StartPoint;
            _Panel.BackColor = Color.Transparent;
            _Panel.Size = _TokenSize;
            Main.MainForm?.Controls.Add(_Panel);

            _PicBox = new();
            _PicBox.Image = character.Image;
            _PicBox.Dock = DockStyle.Fill;
            _PicBox.BackColor = Color.Transparent;
            _PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _PicBox.Paint += Token_Paint;
            //_PicBox.Location = new Point((int)_startX, (int)_startY);
            _Panel.Controls.Add(_PicBox);

            if (character is Monster || character is Player)
            {
                _HealthBar = new ProgressBar();
                _HealthBar.Height = 3;
                _HealthBar.Dock = DockStyle.Top;
                _HealthBar.Maximum = character.Health;
                _HealthBar.Value = character.Health;
                _Panel.Controls.Add(_HealthBar);
                _HealthBar.BringToFront();
            }
        }
        #endregion

        #region Paint Events

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
            if (_CanRotate)
            {
                Image tmpImage;
                tmpImage = RotateImage(_Image, _Angle + 90); //Rotates 90 because images facing up
                _PicBox.Image = tmpImage;
            }
        }
        #endregion

        #region Monster Events
        private void DumbMonsterMove()
        {
            if (_Panel.Left < Main.MainForm.ClientSize.Width / 2) { _StepX = 1; }
            if (_Panel.Left > Main.MainForm.ClientSize.Width / 2) { _StepX = -1; }
            if (_Panel.Top < Main.MainForm.ClientSize.Height / 2) { _StepY = 1; }
            if (_Panel.Left > Main.MainForm.ClientSize.Width / 2) { _StepX = -1; }
        }
        #endregion
    }
}