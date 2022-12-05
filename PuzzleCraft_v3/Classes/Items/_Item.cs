using Microsoft.VisualBasic.Logging;
using PuzzleCraft_v3.Classes.Monsters;
using System.Reflection;
using System.Xml.Linq;

namespace PuzzleCraft_v3.Classes.Items
{
    public abstract class _Item : _Character
    {
        public static List<_Item> ItemList;

        #region Constructor
        static _Item()
        {
            ItemList = new();
        }

        public _Item(string name) //For treasure spawns
        {
            _Name = name;
        }

        public _Item(Point location, string? name) //For monster kills
        {
            
        }
        #endregion

        #region Item Creation
        public static void CreateNewItem(Point loc, string? name)
        {
            switch (name)
            {
                case "arrow":
                    Arrow arrow = new(loc, name);
                    break;

                case "bone":
                    Bone b1 = new(loc, name);
                    break;
            }
        }

        public static _Item CreateTreasure(string item)
        {
            switch (item)
            {
                case "gold":
                    Gold gold = new("gold");
                    return gold;
            }
            return null;
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