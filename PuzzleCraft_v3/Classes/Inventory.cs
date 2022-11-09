using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v3.Classes
{
    static class Inventory
    {
        private static Backpack Pack;

        static Inventory()
        {
            Pack = new();
        }

        public static void GameReset()
        {
            //Code to reset all items in the pack
        }

        public static void ChangeInv(string ItemName, bool AddOrRemove)
        {
            //Code to add or remove from the pack
        }
    }
}
