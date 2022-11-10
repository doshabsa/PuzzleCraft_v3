using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v3.Classes
{
    internal class Player : BaseChar
    {
        #region Properties/Fields

        #endregion

        #region Constructors
        public Player(Bitmap pic, Point loc, Size size) : base(pic, loc, size)
        {
            isDead = false;
            HP = 100;
        }
        #endregion

        #region Methods

        #endregion
    }
}
