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
            _canMove = false;
            _isSmart = false;
            _HP = 1;
            _Speed = 1;
            _Damage = 0;
            _MonsterImage = Resource1.skeleton;
            _MonsterSize = new(50, 50);
            _Token = new(name, _MonsterImage, _MonsterSize, SpawnLocation(_MonsterSize), _HP, false);
        }
    }
}
