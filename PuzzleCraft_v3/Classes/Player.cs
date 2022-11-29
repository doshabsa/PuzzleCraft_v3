using PuzzleCraft_v3.GUI;
using System.Xml.Linq;

namespace PuzzleCraft_v3.Classes
{
    internal class Player : BaseCharacter
    {
        #region Properties/Fields
        public static Player _ThePlayer;
        public Point _ClickLocation;
        private bool _isMoving;
        #endregion

        #region Constructors
        public Player(Bitmap pic, string name) : base(pic, name)
        {
            _CanMove = true;
            _IsSmart = true;
            _ClickLocation = new();
            _TokenSize = new(100,100);
            _ThePlayer = this;
            _Bitmap = pic;
            _Name = name;
            _HP = 100;
            _Speed = 3;
            _Damage = 5;
            _Token = new(this);
            //_Pack = new();
            CharacterList.Add(this);
        }

        protected override void MoveToken()
        {
            _isMoving = true;
            while (_isMoving)
            {
                if (_Token.StepX > 0)
                    _Token.Left += (int)(_Token.StepX < _ClickLocation.X - _Token.Left ? _Token.StepX : _ClickLocation.X - _Token.Left);
                else if (_Token.StepX < 0)
                    _Token.Left += (int)(_Token.StepX > _ClickLocation.X - _Token.Left ? _Token.StepX : _ClickLocation.X - _Token.Left);

                if (_Token.StepY > 0)
                    _Token.Top += (int)(_Token.StepY < _ClickLocation.Y - _Token.Top ? _Token.StepY : _ClickLocation.Y - _Token.Top);
                else if (_Token.StepY < 0)
                    _Token.Top += (int)(_Token.StepY > _ClickLocation.Y - _Token.Top ? _Token.StepY : _ClickLocation.Y - _Token.Top);
                _isMoving = false;
            }
        }
        #endregion
    }
}