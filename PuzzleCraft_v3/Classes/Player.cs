using PuzzleCraft_v3.GUI;

namespace PuzzleCraft_v3.Classes
{
    internal class Player : BaseCharacter
    {
        #region Properties/Fields
        public Point _ClickLocation;
        public static Player? _thePlayer;
        private bool _isMoving;
        private static Backpack? _Pack;

        public Backpack Pack { get { return _Pack; } }
        #endregion

        #region Constructors
        public Player(Bitmap pic, string name, Point loc, Size size) : base(pic, name)
        {
            _canMove = true;
            _isSmart = true;
            _ClickLocation = new();
            _thePlayer = this;
            _Name = name;
            _HP = 100;
            _Speed = 3;
            _Damage = 5;
            _Token = new(pic, size, loc, _HP);
            _Pack = new();
            CharacterList.Add(this);
        }
        #endregion

        protected override void Move()
        {
            _isMoving = true;
            while (_isMoving)
            {
                if (_Token._StepX > 0)
                    _Token.Left += (int)(_Token._StepX < _ClickLocation.X - _Token.Left ? _Token._StepX : _ClickLocation.X - _Token.Left);
                else if (_Token._StepX < 0)
                    _Token.Left += (int)(_Token._StepX > _ClickLocation.X - _Token.Left ? _Token._StepX : _ClickLocation.X - _Token.Left);

                if (_Token._StepY > 0)
                    _Token.Top += (int)(_Token._StepY < _ClickLocation.Y - _Token.Top ? _Token._StepY : _ClickLocation.Y - _Token.Top);
                else if (_Token._StepY < 0)
                    _Token.Top += (int)(_Token._StepY > _ClickLocation.Y - _Token.Top ? _Token._StepY : _ClickLocation.Y - _Token.Top);
                _isMoving = false;
            }
        } 
        //there an issue here causeing player control to teleport/slide at random
        //while loop seems to help with it?
    }
}
