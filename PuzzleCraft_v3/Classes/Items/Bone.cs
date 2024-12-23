﻿namespace PuzzleCraft_v3.Classes.Items
{
    public class Bone : _Item
    {
        public Bone(Point loc, string name) : base(loc, name)
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
            MessageBox.Show("This has been chewed on... gross!");
            Gold.Count += 2;
        }
    }
}
