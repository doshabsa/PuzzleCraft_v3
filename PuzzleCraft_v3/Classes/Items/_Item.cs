﻿namespace PuzzleCraft_v3.Classes.Items
{
    public abstract class _Item : _Character
    {
        public static List<_Item>? ItemList;

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
                case "feather":
                    Feather feather = new(loc, name);
                    break;

                case "bone":
                    Bone b1 = new(loc, name);
                    break;

                case "rabbitfoot":
                    RabbitFoot foot = new(name);
                    break;

                case "wolf_trophy":
                    Wolf_Trophy trophy = new(name);
                    break;

                case "gold":
                    Gold gold = new(name);
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