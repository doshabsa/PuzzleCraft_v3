using PuzzleCraft_v3.Classes.Items;

namespace PuzzleCraft_v3.Classes
{
    static class Inventory
    {
        public static List<_Item> InventoryList;
        //public static int ItemCount 
        //{ 
        //    get 
        //    { 
        //        return InventoryList.Count;
        //    } 
        //}

        static Inventory()
        {
            InventoryList = new();
        }

        public async static void PickUp(_Item newItem)
        {
            if (InventoryList.Count < 6)
            {
                _Item.ItemList.Remove(newItem);
                InventoryList.Add(newItem);
                Main.MainForm?.Controls.Remove(newItem.Token);
            }
            else
            {
                _Item.ItemList.Remove(newItem);
                newItem.Token.Dispose();
            }
        }
    }
}