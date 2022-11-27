using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.GUI.Token;

namespace PuzzleCraft_v3.Classes.Monsters
{
    public abstract class Monster : BaseCharacter
    {
        #region Properties
        protected Panel? _Panel;
        protected Bitmap? _Image;
        protected PictureBox? _PicBox;
        protected ProgressBar? _HealthBar;
        protected Size _TokenSize;
        protected bool _isMonster = false;
        protected bool _RotationFlag = false;
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
                if (!_isMonster)
                {
                    if (value + _TokenSize.Height > Main.MainForm?.ClientSize.Height)
                        _startY = (int)Main.MainForm?.ClientSize.Height - _TokenSize.Height;
                }
                else
                    _startY = value;
            }
        }
        public Bitmap Image { get { return _Image; } }
        #endregion

        #region Constructors
        public Monster() : base()
        {

        }
        #endregion

        #region Methods
        public static void CreateNewMonster()
        {
            switch (_rnd.Next(0, 1))
            {
                case 0:
                    Raven m0 = new();
                    break;

                case 1:
                    Skeleton m1 = new();
                    break;
            }
        }

        public static void DeathDrop(Monster monster)
        {
            string tmp = "";
            switch (_rnd.Next(0, 1)) //Triggers random item drops
            {
                case 0:
                    tmp = "arrow";
                    break;

                default:
                    tmp = "";
                    break;
            }

            if(tmp != "")
            {
                Item drop = new();
            }
        }
        #endregion
    }
}
