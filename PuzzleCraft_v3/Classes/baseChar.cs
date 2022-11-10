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
        public Token Token;
        public static Main? mainForm;

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
            mainForm?.Controls.Add(Token);
        }
        #endregion

        #region Methods
        public virtual void Deletion()
        {
            mainForm?.Controls.Remove(Token);
        }

        public void TestMethod()
        {
            Token.X += 50;
        }
        #endregion
    }
}
