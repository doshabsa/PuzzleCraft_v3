using Microsoft.VisualBasic.Logging;
using PuzzleCraft_v3.Classes.Monsters;
using System.Reflection;
using System.Xml.Linq;

namespace PuzzleCraft_v3.Classes.Items
{
    public abstract class Item : BaseCharacter
    {
        public static List<Item> ItemList;

        #region Constructor
        static Item()
        {
            ItemList = new();
        }

        public Item(Point location, string? name)
        {
            
        }

        public static void CreateNewItem(Point loc, string? name)
        {
            switch (name)
            {
                case "dead":

                    break;

                case "arrow":
                    Arrow arrow = new(loc, name);
                    break;

                case "bone":
                    Bone b1 = new(loc, name);
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