﻿namespace PuzzleCraft_v3.Classes.Items
{
    public class Wolf_Trophy : _Item
    {
        protected static int _Wolf_TrophyCount = 0;

        public static int Count
        {
            get { return _Wolf_TrophyCount; }
            set
            {
                _Wolf_TrophyCount -= value;
            }
        }

        public Wolf_Trophy(string name) : base(name)
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
                _Token = new(this);
                _Wolf_TrophyCount++;
                _Item.ItemList.Add(this);
            }
        }

        public override void UseItem()
        {
            MessageBox.Show("Can be sold for gold.");
            Gold.Count += 10;
        }
    }
}
