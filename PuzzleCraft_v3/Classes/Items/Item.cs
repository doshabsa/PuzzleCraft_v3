namespace PuzzleCraft_v3.Classes.Items
{
    public class Item : BaseCharacter
    {
        public static List<Item> ItemList;

        #region Constructor
        static Item()
        {
            ItemList = new();
        }

        public Item(string name)
        {
            _Bitmap = GetImage(name);
            _TokenSize = new Size(40, 40);
            _Name = name;
            _HP = 1;
            _Damage = 0;
            _CanMove = false;
            _IsDead = false;
            _IsSmart = false;
            _Token = new(this);
            ItemList.Add(this);
        }
        #endregion

        #region Methods
        //Rather than new images, static ones likely could be used (making GC work this time tho)
        private Bitmap GetImage(string name)
        {
            Bitmap? pic = null;
            switch (name)
            {
                case "arrow":
                    pic = new(Resource1.arrow);
                    break;
            }
            return pic;
        }
        #endregion
    }
}