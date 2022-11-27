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
        #endregion

        #region Constructors
        public Player(Bitmap pic, string name)
        {
            _Name = name;
            _CanMove = true;
            _IsSmart = true;
            _CanRotate = true;
            _Speed = 2;
            _Damage = 3;
            _Image = pic;
            _Size = new(50, 50);
            _ClickLocation = new();
            _thePlayer = this;
            _HP = 100;
            _Pack = new();
            _Token = new(this);
            PlayerTimer.Start();
        }
        #endregion

        protected override void Move()
        {
            _isMoving = true;
            while (_isMoving)
            {
                if (_Token._StepX > 0)
                    _Token.Panel.Left += (int)(_Token._StepX < _ClickLocation.X - _Token.Panel.Left ? _Token._StepX : _ClickLocation.X - _Token.Panel.Left);
                else if (_Token._StepX < 0)
                    _Token.Panel.Left += (int)(_Token._StepX > _ClickLocation.X - _Token.Panel.Left ? _Token._StepX : _ClickLocation.X - _Token.Panel.Left);

                if (_Token._StepY > 0)
                    _Token.Panel.Top += (int)(_Token._StepY < _ClickLocation.Y - _Token.Panel.Top ? _Token._StepY : _ClickLocation.Y - _Token.Panel.Top);
                else if (_Token._StepY < 0)
                    _Token.Panel.Top += (int)(_Token._StepY > _ClickLocation.Y - _Token.Panel.Top ? _Token._StepY : _ClickLocation.Y - _Token.Panel.Top);
                _isMoving = false;
            }
        } 
        //there an issue here causeing player control to teleport/slide at random
        //while loop seems to help with it?
    }
}
