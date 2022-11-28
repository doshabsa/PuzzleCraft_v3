using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.GUI.Token;
using System.Xml.Linq;

namespace PuzzleCraft_v3.Classes.Monsters
{
    public abstract class Monster : BaseCharacter
    {
        #region Constructors
        public Monster() : base()
        {

        }
        #endregion

        #region Methods
        public static void CreateNewMonster()
        {
            switch (_rnd.Next(0, 1))
            {
                case 0:
                    Raven m0 = new();
                    break;

                case 1:
                    Skeleton m1 = new();
                    break;
            }
        }

        public static void DeathDrop(Monster monster)
        {
            string tmp = "";
            switch (_rnd.Next(0, 1)) //Triggers random item drops
            {
                case 0:
                    tmp = "arrow";
                    break;

                default:
                    tmp = "";
                    break;
            }

            if(tmp != "")
            {
                Item drop = new();
            }
        }
        #endregion
    }
}
