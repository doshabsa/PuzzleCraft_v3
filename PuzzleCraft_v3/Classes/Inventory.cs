//namespace PuzzleCraft_v3.Classes
//{
//    static class Inventory
//    {
//        //public static List<Item> InventoryList;
//        public static int ItemCount { get { return InventoryList.Count; } }

//        static Inventory()
//        {
//            InventoryList = new();
//        }

//        public async static void PickUp(Item newItem)
//        {
//            if (InventoryList.Count < 6)
//            {
//                Item.ItemList.Remove(newItem);
//                InventoryList.Add(newItem);
//                Main.MainForm?.Controls.Remove(newItem.Token);
//            }
//            else
//            {
//                Item.ItemList.Remove(newItem);
//                newItem.Token.Dispose();
//            }
//        }
//    }
//}