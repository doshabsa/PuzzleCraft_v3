using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v3.Classes.Monsters
{
    internal class Skeleton : Monster
    {
        public Skeleton(string name) : base(name)
        {
            canMove = false;
            isSmart = false;
            HP = 1;
            Speed = 1;
            Damage = 1;
            MonsterImage = Resource1.skeleton;
            MonsterSize = new(50, 50);
            Token = new(MonsterImage, MonsterSize, SpawnLocation(MonsterSize), HP);
        }
    }
}
