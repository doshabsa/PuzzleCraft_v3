using PuzzleCraft_v3.Classes.Items;

namespace PuzzleCraft_v3.Classes.Monsters
{
    public abstract class Monster : BaseCharacter
    {
        #region Properties/Fields
        protected static Random _rnd = new Random();
        protected Size _MonsterSize;
        protected Bitmap _MonsterImage;
        private Monster thisMonster;
        #endregion

        #region Constructors
        public Monster(string name) : base(name)
        {
            _isDead = false;
            thisMonster = this;
            CharacterList.Add(this);
        }
        #endregion

        #region Methods
        public static void CreateNewMonster()
        {
            switch (_rnd.Next(0, 1))
            {
                case 0:
                    Raven m0 = new("raven");
                    break;

                case 1:
                    Skeleton m1 = new("skeleton");
                    break;
            }
        }

        public static Point SpawnLocation(Size newMonster)
        {
            Point spawnPoint = new(_rnd.Next(0, Main.MainForm.ClientSize.Width - newMonster.Width), 
                                        _rnd.Next(0, Main.MainForm.ClientSize.Height - newMonster.Height));
            return spawnPoint;
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
                Item drop = new(tmp, new Point((int)Math.Round(monster.Token.LocX), (int)Math.Round(monster.Token.LocX)));
            }
        }
        #endregion
    }
}
