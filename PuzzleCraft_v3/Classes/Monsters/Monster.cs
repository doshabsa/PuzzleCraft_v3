using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.Classes.Monsters;

namespace PuzzleCraft_v3.Classes
{
    public abstract class Monster : BaseCharacter
    {
        #region Fields
        protected bool isSmart;
        protected string _ItemDrop0;
        protected string _ItemDrop1;
        protected string _ItemDrop2;
        protected string _ItemDrop3;
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
            int newDrop = rnd.Next(0, 4);

            switch (newDrop)
            {
                case 0:
                    Item item0 = new(monster.Token.Location, monster._ItemDrop0);
                    break;

                case 1:
                    Item item1 = new(monster.Token.Location, monster._ItemDrop1);
                    break;

                case 2:
                    Item item2 = new(monster.Token.Location, monster._ItemDrop2);
                    break;

                case 3:
                    Item item3 = new(monster.Token.Location, monster._ItemDrop3);
                    break;
            }
        }
        #endregion
    }
}