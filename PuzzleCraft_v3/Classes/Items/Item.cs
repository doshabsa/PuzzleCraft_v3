using Microsoft.VisualBasic.Logging;
using PuzzleCraft_v3.Classes.Monsters;
using System.Reflection;
using System.Xml.Linq;

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

        public Item()
        {

        }

        public Item(Point location, string? name)
        {
            
        }

        public static void CreateNewItem(Point loc, string? name)
        {
            switch (name)
            {
                case "arrow":
                    Arrow arrow = new(loc, name);
                    break;

                case "":
                    Skeleton m1 = new();
                    break;
            }
        }
        #endregion

        #region Methods
        public virtual void UseItem()
        {
            //code to determine item effects on use
        }
        #endregion
    }
}