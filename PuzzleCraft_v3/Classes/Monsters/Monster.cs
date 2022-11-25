using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PuzzleCraft_v3.Classes.Monsters
{
    internal class Monster : BaseCharacter
    {
        #region Properties/Fields
        protected static Random rnd = new Random();
        protected Size MonsterSize;
        protected Bitmap MonsterImage;
        #endregion

        #region Constructors
        public Monster(string name) : base(name)
        {
            isDead = false;
            CharacterList.Add(this);
        }
        #endregion

        #region Methods
        public static void CreateNewMonster()
        {
            switch (rnd.Next(0, 1))
            {
                case 0:
                    Skeleton m1 = new("skeleton");
                    Raven m0 = new("raven");
                    break;

                case 1:
                    Raven m2 = new("raven");
                    break;
            }
        }

        public static Point SpawnLocation(Size newMonster)
        {
            Point spawnPoint = new(rnd.Next(0, MainForm.ClientSize.Width - newMonster.Width), rnd.Next(0, MainForm.ClientSize.Height - newMonster.Height));
            return spawnPoint;
        }
        #endregion
    }
}
