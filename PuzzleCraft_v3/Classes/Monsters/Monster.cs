using PuzzleCraft_v3.Classes.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PuzzleCraft_v3.Classes
{
    public abstract class Monster : BaseCharacter
    {
        #region Properties/Fields
        protected bool isSmart;
        #endregion

        #region Constructors
        public Monster() : base()
        {

        }
        #endregion

        #region Methods
        public static void CreateNewMonster()
        {
            switch (rnd.Next(0, 1))
            {
                case 0:
                    Raven m0 = new();
                    break;

                case 1:
                    Skeleton m1 = new();
                    break;
            }
        }
        #endregion
    }
}