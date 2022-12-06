namespace PuzzleCraft_v3.Classes.Items
{
    /*
     Gold is handled differently than other items.
     Can be used to purchase items from the store (which currently does not exist.)
     */

    public class Gold : _Item
    {
        public static int _GoldCount;

        public static int Count
        {
            get { return _GoldCount; }
            set
            {
                _GoldCount = value;

            }
        }

        static Gold()
        {
            _GoldCount = 0;
        }

        public Gold(string name) : base(name)
        {
            _Name = name;
            _TokenSize = new Size(40, 40);
            _HP = 1;
            _Damage = 0;
            _CanMove = false;
            _IsSmart = false;
            _Bitmap = GetImage(name);
            _Token = new(this);
            _Item.ItemList.Add(this);
        }

        public override void UseItem()
        {
            MessageBox.Show("Can be used to purchase other items."); //Store is not actually available
            Gold.Count += 5;
        }
    }
}
