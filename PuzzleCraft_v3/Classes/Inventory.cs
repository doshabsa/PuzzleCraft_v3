using PuzzleCraft_v3.Classes.Items;

namespace PuzzleCraft_v3.Classes
{
    static class Inventory
    {
        public static List<_Item> InventoryList;
        private static Panel pnlTrackers = new();
        private static Label lblItems = new();

        static Inventory()
        {
            InventoryList = new();
        }

        public static void PickUp(_Item newItem)
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

        private static void SetUpTrackerPanel()
        {
            pnlTrackers.Size = new(75, 75);
            pnlTrackers.BackColor = Color.OldLace;
            pnlTrackers.BorderStyle = BorderStyle.FixedSingle;

            foreach(_Item item in InventoryList)
            {

            }
        }
    }
}