using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v3.Classes.Items
{
    public class Arrow : _Item
    {
        public Arrow(Point loc, string name) : base(loc, name)
        {
            if (name != null)
            {
                _Name = name;
                _TokenSize = new Size(40, 40);
                _HP = 1;
                _Damage = 0;
                _CanMove = false;
                _IsSmart = false;
                _Bitmap = GetImage(name);
                _Token = new(this, loc);
                ItemList.Add(this);
            }
        }

        public override void UseItem()
        {
            MessageBox.Show("Shoots things!");
        }
    }
}
