using PuzzleCraft_v3.GUI;
using System.Threading;
using System.Xml.Linq;

namespace PuzzleCraft_v3.Classes
{
    internal class Player : _Character
    {
        public static Player _ThePlayer;
        protected Backpack _Pack;
        protected QuestLog _Log;

        public Backpack Pack 
        { 
            get {  return _Pack; }
            set { _Pack = value; }
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
            _Pack = new();
            _Log = new();
            _Token = new(this);
            CharacterList.Add(this);
        }
        #endregion

        #region Methods

        /*
         I initally had issues in which the player token would freak out once it reached it's destination point.
        To prevent this without breaking angles, I changed constantly running timers to only fire when the mouse
        button is held down. I felt this has grander dreams for cross platform, as this would be a common control 
        for many mobile games.
         */

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

        public static void GameOver()
        {
            _ThePlayer.Token.Bitmap = Resource1.dead;
        }
        #endregion
    }
}