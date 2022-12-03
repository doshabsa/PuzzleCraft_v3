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
    internal class Wolf2 : _Monster
    {
        public Wolf2() : base()
        {
            _ItemDrop0 = "arrow";
            _ItemDrop1 = "arrow";
            _ItemDrop2 = "arrow";
            _ItemDrop3 = "arrow";

            _Name = "wolf2";
            _CanMove = true;
            _IsSmart = true;
            _TokenSize = new(50, 50);
            _Bitmap = GetImage(_Name);
            _HP = 10;
            _Speed = 2;
            _Damage = 10;
            _Token = new(this);
            CharacterList.Add(this);
        }
    }
}
