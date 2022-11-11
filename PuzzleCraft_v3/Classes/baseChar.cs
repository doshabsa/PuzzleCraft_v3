using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v3.Classes
{
    internal class BaseChar
    {
        #region Properties/Fields
        protected bool isDead;
        private Token Token;
        public static List<Token> TokenList = new();
        public static Main? MainForm;
        public BaseChar BaseCharacter;

        protected int HP;
        public int Health
        {
            get { return HP; }
            set
            {
                if (value < 0) HP = 0;
                else if (HP == 0) isDead = true;
                else HP = value;
            }
        }
        public Point GetLocation { get { return Token.Location; } }
        public Size GetDimensions { get { return Token.Size; } }
        public bool IsDead {  get { return isDead; } }
        #endregion

        #region Constructors
        public BaseChar(Bitmap pic, Point loc, Size size)
        {
            Token = new(pic, loc, size);
            MainForm?.Controls.Add(Token);
            TokenList.Add(Token);
        }
        #endregion

        #region Methods
        public virtual void Deletion()
        {
            MainForm?.Controls.Remove(Token);
        }
        #endregion
    }
}
