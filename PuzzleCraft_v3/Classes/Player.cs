using PuzzleCraft_v3.GUI;
using System.Xml.Linq;

namespace PuzzleCraft_v3.Classes
{
    internal class Player : BaseCharacter
    {
        #region Fields
        public static Player _ThePlayer;
        public Backpack Pack 
        { 
            get 
            { 
                return _Pack;
            } 
        }
        #endregion

        static Player()
        {

        }

        #region Constructors
        public Player(Bitmap pic, string name) : base(pic, name)
        {
            _CanMove = true;
            _IsSmart = true;
            _TokenSize = new(60, 60);
            _ThePlayer = this;
            _Bitmap = pic;
            _Name = name;
            _HP = 100;
            _Speed = 3;
            _Damage = 5;
            _Token = new(this);
            _Pack = new();
            CharacterList.Add(this);
        }
        #endregion

        #region Methods
        protected override void MoveToken()
        {
            if (Token.StepX > 0)
            {
                Token.Left += (int)(Token.StepX < Main.ClickLocation.X - Token.Left ? Token.StepX : Main.ClickLocation.X - Token.Left);
            }
            else if (Token.StepX < 0)
            {
                Token.Left += (int)(Token.StepX > Main.ClickLocation.X - Token.Left ? Token.StepX : Main.ClickLocation.X - Token.Left);
            }

            if (Token.StepY > 0)
            {
                Token.Top += (int)(Token.StepY < Main.ClickLocation.Y - Token.Top ? Token.StepY : Main.ClickLocation.Y - Token.Top);
            }
            else if (Token.StepY < 0)
            {
                Token.Top += (int)(Token.StepY > Main.ClickLocation.Y - Token.Top ? Token.StepY : Main.ClickLocation.Y - Token.Top);
            }
        }
        #endregion
    }
}