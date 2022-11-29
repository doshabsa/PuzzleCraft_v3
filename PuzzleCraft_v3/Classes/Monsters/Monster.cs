using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.Classes.Monsters;

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

        public static void DeathDrop(Monster monster)
        {
            string tmp = "";
            switch (rnd.Next(0, 1)) //Triggers random item drops
            {
                case 0:
                    tmp = "arrow";
                    break;

                default:
                    tmp = "";
                    break;
            }

            Item drop = new(tmp);
        }
        #endregion
    }
}