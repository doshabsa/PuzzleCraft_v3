using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.Classes.Monsters;
using static System.Windows.Forms.AxHost;

namespace PuzzleCraft_v3.Classes
{
    static class Inventory
    {
        public static List<Item> InventoryList;
        public static int ItemCount { get { return InventoryList.Count; } }

        static Inventory()
        {
            InventoryList = new();
        }

        public async static void PickUp(Item newItem)
        {
            if (InventoryList.Count < 6)
            {
                Item.ItemList.Remove(newItem);
                InventoryList.Add(newItem);
                Main.MainForm?.Controls.Remove(newItem.Token);
            }
            else
            {
                Item.ItemList.Remove(newItem);
                newItem.Token.Dispose();
            }
        }
    }
}
