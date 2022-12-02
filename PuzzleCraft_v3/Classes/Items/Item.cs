using System.Reflection;

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

        public Item(Point location, string name)
        {
            if(name != null)
            {
                _Bitmap = GetImage(name);
                _TokenSize = new Size(40, 40);
                _Name = name;
                _HP = 1;
                _Damage = 0;
                _CanMove = false;
                _IsDead = false;
                _IsSmart = false;
                _Token = new(this, location);
                ItemList.Add(this);
            }
            //else let this dispose, as no item was dropped
        }
        #endregion

        #region Methods
        //This is the most excitng thing ever; made my spawn drops x99999999 times easier to manage!
        private Bitmap? GetImage(string name)
        {
            object? DesiredItem = Resource1.ResourceManager.GetObject(name);
            Bitmap? pic = (Bitmap)DesiredItem;
            return pic;
        }
        #endregion
    }
}