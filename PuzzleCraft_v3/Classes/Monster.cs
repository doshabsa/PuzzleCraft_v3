using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v3.Classes
{
    internal class Monster : BaseChar
    {
        #region Properties/Fields
        #endregion

        #region Constructors
        public Monster(Bitmap pic, string name, Point loc, Size size) : base(pic, loc, size)
        {
            isDead = false;
            HP = GetMonsterHP(name);
        }
        #endregion

        #region Methods
        private static int GetMonsterHP(string name)
        {
            int ret = 0;
            switch (name)
            {
                default:
                    break;
            }
            return ret;
        }
        #endregion
    }
}
