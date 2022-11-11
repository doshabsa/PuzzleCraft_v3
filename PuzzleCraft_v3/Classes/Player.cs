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
        public void Move()
        {
            if (PlayerKey == KeyMove.up) { Token.MoveTop(this, true); }
            if (PlayerKey == KeyMove.right) { Token.MoveLeft(this, false); }
            if (PlayerKey == KeyMove.down) { Token.MoveTop(this, false); }
            if (PlayerKey == KeyMove.left) { Token.MoveLeft(this, true); }
        }
        #endregion
    }
}
