using PuzzleCraft_v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PuzzleCraft_v3.Classes.BaseChar;

namespace PuzzleCraft_v3.Classes
{
    public class Player : BaseChar
    {
        #region Properties/Fields
        public static Player? thePlayer;
        public enum KeyMove { none, up, down, left, right, space }
        public static KeyMove PlayerKey;
        public static Point NewLocation;
        #endregion

        #region Constructors
        public Player(Bitmap pic, Point loc, Size size) : base(pic, loc, size)
        {
            isDead = false;
            HP = 100;
            Speed = 5;
            PlayerKey = KeyMove.none;
            thePlayer = this;
            BaseChar.CharacterList.Add(this);
        }
        #endregion

        #region Methods
        protected override void Move()
        {
            if(NewLocation.Y != Token.Location.Y)
            {
                if (NewLocation.Y > Token.Location.Y)
                    Token.Top += Speed;
                else if (NewLocation.Y < Token.Location.Y)
                    Token.Top -= Speed;
            }
            if (NewLocation.X != Token.Location.X)
            {
                if (NewLocation.X > Token.Location.X)
                    Token.Left += Speed;
                else if (NewLocation.X < Token.Location.X)
                    Token.Left -= Speed;
            }
        }
        #endregion
    }
}
