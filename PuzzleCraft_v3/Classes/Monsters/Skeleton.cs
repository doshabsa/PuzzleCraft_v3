using PuzzleCraft_v3.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PuzzleCraft_v3.Classes.Monsters
{
    internal class Skeleton : _Monster
    {
        public Skeleton() : base()
        {
            _ItemDrop0 = "arrow";
            _ItemDrop1 = null;
            _ItemDrop2 = null;
            _ItemDrop3 = null;

            _CanMove = false;
            _IsSmart = false;
            _Bitmap = Resource1.skeleton;
            _Name = "Skeleton";
            _HP = 1;
            _Speed = 0;
            _Damage = 0;
            _Token = new(this);
            CharacterList.Add(this);
        }
    }
}
