using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuzzleCraft_v3.Classes;
using PuzzleCraft_v3.Classes.Monsters;

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

        public Item(string name, Point loc) : base(name)
        {
            _Name = name;
            _HP = 1;
            _Damage = 0;
            _canMove = false;
            _isDead = false;
            _isSmart = false;
            _Token = FetchToken(name, loc);
            ItemList.Add(this);
        }
        #endregion

        #region Methods
        private Token FetchToken(string name, Point loc)
        {
            Token itemToken = new(name, GetImage(name), loc);
            return itemToken;
        }

        private Bitmap? GetImage(string name)
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
