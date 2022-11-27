using PuzzleCraft_v3.Classes;
using PuzzleCraft_v3.Classes.Monsters;
using System.Drawing.Drawing2D;

namespace PuzzleCraft_v3.GUI.Token
{
    public class BaseToken
    {
        /*
        Issues:
           - if token is made with a transparent background, things break (ticks, labels, monster tokens, etc.)
           - if background is light color, token images WILL artifact. might still do this with darker bag color, not bothering with testing that
        */

        #region Properties
        public static List<BaseToken> TokenList;
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
        static BaseToken()
        {
            _rnd = new();
            TokenList = new();
        }

        public BaseToken(BaseCharacter character)
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
            _PicBox.Paint += Token_Paint;
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
        #endregion
        #endregion

        public void UpdateTokenHP(BaseCharacter character)
        {
            _HealthBar.Value = character.Health;
        }


        public static void Demo(BaseToken token)
        {
            token._PicBox.Invalidate(true);
        }

        public void UpdatePictureDirection(float angle)
        {
            _Angle = angle;
            _PicBox.Image = RotateImage(Image, _Angle);
            TakeSteps(this);
        }

        public static void TakeSteps(BaseToken token)
        {
            if (token._Character is Monster)
            {
                token.LocX += token._StepX;
                token.LocY += token._StepY;
                token._Panel.Left = (int)token.LocX;
                token._Panel.Top = (int)token.LocY;
            }
            else if (token._Character is Player)
            {
                bool _isMoving = true;
                while (_isMoving)
                {
                    if (token._StepX > 0)
                        token.Panel.Left += (int)(token._StepX < Player._thePlayer._ClickLocation.X - token.Panel.Left ? token._StepX : Player._thePlayer._ClickLocation.X - token.Panel.Left);
                    else if (token._StepX < 0)
                        token.Panel.Left += (int)(token._StepX > Player._thePlayer._ClickLocation.X - token.Panel.Left ? token._StepX : Player._thePlayer._ClickLocation.X - token.Panel.Left);

                    if (token._StepY > 0)
                        token.Panel.Top += (int)(token._StepY < Player._thePlayer._ClickLocation.Y - token.Panel.Top ? token._StepY : Player._thePlayer._ClickLocation.Y - token.Panel.Top);
                    else if (token._StepY < 0)
                        token.Panel.Top += (int)(token._StepY > Player._thePlayer._ClickLocation.Y - token.Panel.Top ? token._StepY : Player._thePlayer._ClickLocation.Y - token.Panel.Top);
                    _isMoving = false;
                }
            }
        }

        #region Paint Events
        private static Image RotateImage(Image img, float rotationAngle)
        {
            Bitmap bmp = new Bitmap(img.Size.Width, img.Height);
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
            DetermineTrajectory(this);
        }

        private static void DetermineTrajectory(BaseToken token)
        {
            if (token._Character is Player)
                token.CalcTrajectory(token.Panel.Left, token.Panel.Top, Player._thePlayer._ClickLocation.X, Player._thePlayer._ClickLocation.Y);
            if (token._Character is Monster && Player._thePlayer is not null)
                token.CalcTrajectory(token.Panel.Left, token.Panel.Top, Player._thePlayer.Token.Panel.Left, Player._thePlayer.Token.Panel.Top);
        }

        public void CalcTrajectory(int startX, int startY, int endX, int endY)
        {
            //await Task.Run(() =>
            //{
            double deltaX = endX - startX;
            double deltaY = endY - startY;
            double radians = Math.Atan2(deltaY, deltaX);
            double angle = radians * (180 / Math.PI);

            this.UpdatePictureDirection((float)angle);
            this._StepX = _Character.Speed * Math.Cos(radians);
            this._StepY = _Character.Speed * Math.Sin(radians);
            // });
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