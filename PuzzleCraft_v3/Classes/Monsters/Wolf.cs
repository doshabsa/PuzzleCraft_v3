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
    internal class Wolf : Monster
    {
        public Wolf() : base()
        {
            _ItemDrop0 = null;
            _ItemDrop1 = null;
            _ItemDrop2 = null;
            _ItemDrop3 = null;

            _Name = "wolf";
            _CanMove = true;
            _IsSmart = true;
            _TokenSize = new(50, 50);
            _Bitmap = GetImage(_Name);
            _HP = 1;
            _Speed = 1;
            _Damage = 1;
            _Token = new(this);
            CharacterList.Add(this);
        }
    }
}
