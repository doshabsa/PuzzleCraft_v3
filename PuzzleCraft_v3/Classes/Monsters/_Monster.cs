using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.Classes.Monsters;

namespace PuzzleCraft_v3.Classes
{
    public abstract class _Monster : BaseCharacter
    {
        #region Fields
        protected bool isSmart;
        protected string? _ItemDrop0;
        protected string? _ItemDrop1;
        protected string? _ItemDrop2;
        protected string? _ItemDrop3;
        #endregion

        #region Constructors
        public _Monster() : base()
        {

        }
        #endregion

        #region Methods
        public static void CreateNewMonster()
        {
            switch (rnd.Next(0, 4))
            {
                case 0:
                    Raven m0 = new();
                    break;

                case 1:
                    Skeleton m1 = new();
                    break;

                case 2:
                    Wolf w1 = new();
                    break;

                //case 3:
                //    Wolf2 w2 = new();
                //    break;
            }
        }

        public static (Point, string?) DeathDrop(_Monster monster)
        {
            int newDrop = rnd.Next(0, 4);
            string? tmp = null;
            switch (newDrop)
            {
                case 0:
                    tmp = monster._ItemDrop0;
                    break;

                case 1:
                    tmp= monster._ItemDrop1;
                    break;

                case 2:
                    tmp = monster._ItemDrop2;
                    break;

                case 3:
                    tmp = monster._ItemDrop3;
                    break;
            }
            return (monster.Token.Location, tmp);
        }
        #endregion
    }
}