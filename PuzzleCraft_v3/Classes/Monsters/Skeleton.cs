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
    internal class Skeleton : Monster
    {
        public Skeleton() : base()
        {
            _ItemDrop0 = "bone";
            _ItemDrop1 = "bone";
            _ItemDrop2 = "bone";
            _ItemDrop3 = "bone";

            _Name = "skeleton";
            _CanMove = false;
            _IsSmart = false;
            _TokenSize = new(40, 40);
            _Bitmap = GetImage(_Name);
            _HP = 1;
            _Speed = 0;
            _Damage = 0;
            _Token = new(this);
            CharacterList.Add(this);
        }
    }
}
