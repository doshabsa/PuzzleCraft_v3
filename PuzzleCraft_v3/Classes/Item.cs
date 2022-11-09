using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v3.Classes
{
    internal class Item : BaseChar
    {
        #region Properties/Fields
        private List<Image>? ListItemTokens;
        #endregion

        #region Constructors
        public Item(Bitmap pic, string name, Point loc, Size size) : base(pic, loc, size)
        {

        }
        #endregion

        #region Methods

        #endregion
    }
}
