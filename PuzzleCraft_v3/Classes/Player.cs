using PuzzleCraft_v3.GUI;
using System.Xml.Linq;

namespace PuzzleCraft_v3.Classes
{
    internal class Player : BaseCharacter
    {
        #region Properties/Fields
        public static Player _ThePlayer;
        public static Point _ClickLocation;
        private bool _isMoving;
        #endregion

        static Player()
        {
            Main.GameLive += UpdateLocation;
        }

        #region Constructors
        public Player(Bitmap pic, string name) : base(pic, name)
        {
            _CanMove = true;
            _IsSmart = true;
            _ClickLocation = new();
            _TokenSize = new(100, 100);
            _ThePlayer = this;
            _Bitmap = pic;
            _Name = name;
            _HP = 100;
            _Speed = 3;
            _Damage = 5;
            _Token = new(this);
            _Pack = new();
            CharacterList.Add(this);
            
            //Operation obj = new operation(Program.Addition);
        }

        private static void UpdateLocation(Point e)
        {
            _ClickLocation = e;
        }

        protected override void MoveToken()
        {
            if (Token.StepX > 0)
            {
                Token.Left += (int)(Token.StepX < _ClickLocation.X - Token.Left ? Token.StepX : _ClickLocation.X - Token.Left);
            }
            else if (Token.StepX < 0)
            {
                Token.Left += (int)(Token.StepX > _ClickLocation.X - Token.Left ? Token.StepX : _ClickLocation.X - Token.Left);
            }

            if (Token.StepY > 0)
            {
                Token.Top += (int)(Token.StepY < _ClickLocation.Y - Token.Top ? Token.StepY : _ClickLocation.Y - Token.Top);
            }
            else if (Token.StepY < 0)
            {
                Token.Top += (int)(Token.StepY > _ClickLocation.Y - Token.Top ? Token.StepY : _ClickLocation.Y - Token.Top);
            }
        }
        #endregion
    }
}