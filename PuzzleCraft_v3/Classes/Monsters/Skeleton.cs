using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v3.Classes.Monsters
{
    internal class Skeleton : Monster
    {
        public Skeleton()
        {
            _CanMove = false;
            _IsSmart = false;
            _HP = 1;
            _Speed = 1;
            _Damage = 0;
            _Image = Resource1.skeleton;
            _Size = new(50, 50);
            _Token = new(this);
        }
    }
}
