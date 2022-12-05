using PuzzleCraft_v3.Classes.Items;

namespace PuzzleCraft_v3.Classes
{
    static class Inventory
    {
        public static List<_Item> InventoryList;
        private static Panel pnlTrackers;
        private static TableLayoutPanel tlpTable;
        private static Label lblGold;
        private static int RowCount;

        static Inventory()
        {
            InventoryList = new();
            pnlTrackers = new();
            tlpTable = new();
            lblGold = new();
            RowCount = 0;
            SetUpTrackerPanel();
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
            pnlTrackers.Size = new(100, 100);
            pnlTrackers.Location = new Point(Main.MainForm.ClientSize.Width - pnlTrackers.Width - 6, 6);
            pnlTrackers.BackColor = Color.OldLace;
            pnlTrackers.BorderStyle = BorderStyle.FixedSingle;
            Main.MainForm?.Controls.Add(pnlTrackers);

            tlpTable.Dock = DockStyle.Fill;
            pnlTrackers.Controls.Add(tlpTable);

            lblGold.Dock = DockStyle.Fill;
            lblGold.Font = new Font("Arial", 12);
            lblGold.Text = $"Gold: ${Gold.Count}";
            tlpTable.Controls.Add(lblGold, 0, 0);
        }

        public static void UpdateTrackers()
        {
            foreach (_Item item in InventoryList)
            {
                if (item is Gold)
                    lblGold.Text = $"Gold: ${Gold.Count}";
            }
        }
    }
}