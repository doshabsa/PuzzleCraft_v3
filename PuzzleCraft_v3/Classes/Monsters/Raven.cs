using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PuzzleCraft_v3.Classes.Monsters
{
    internal class Raven : Monster
    {
        public Raven(string name) : base(name)
        {
            canMove = true;
            isSmart = true;
            HP = 1;
            Speed = 1;
            Damage = 1;
            MonsterImage = Resource1.raven;
            MonsterSize = new(35, 35);
            Token = new(MonsterImage, MonsterSize, SpawnLocation(MonsterSize), HP);
        }
    }
}
