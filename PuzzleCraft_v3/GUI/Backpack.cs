using PuzzleCraft_v3.Classes;
using PuzzleCraft_v3.Classes.Items;
using System.Windows.Forms;

namespace PuzzleCraft_v3.GUI
{
    public partial class Backpack : UserControl
    {
        //Backpack items cause random background discolouration 
        //within the backpack over time (is beige in color)
        #region Fields
        private static List<PictureBox> BoxList;
        private static List<Label> LabelList;
        private bool IsVisible = false;
        private PictureBox? selected;
        #endregion

        static Backpack()
        {
            BoxList = new();
            LabelList = new();
        }

        #region Constructor
        public Backpack()
        {
            InitializeComponent();
            this.Font = new Font("Arial", 12);
            SetupLists(tlpTable);
            this.Visible = false;
            this.Location = new Point(3, 3);
            Main.MainForm?.Controls.Add(this);
        }
        #endregion

        #region Methods

        #region Editing Controls
        public void ToggleBag()
        {
            if (!IsVisible)
            {
                IsVisible = true;
                this.Show();
                this.BringToFront();
            }
            else
            {
                IsVisible = false;
                this.Hide();
            }
        }

        private void SetupLists(Control control)
        {
            foreach (PictureBox pic in control.Controls.OfType<PictureBox>())
                BoxList.Add(pic);
            foreach (Label lbl in control.Controls.OfType<Label>())
                LabelList.Add(lbl);
        }

        #endregion

        #region Item Display
        public static void UpdateItems()
        {
            for (int i = 0; i < 6; i++)
            {
                BoxList[i].Image = null;
                LabelList[i].Text = null;
            }

            for (int i = 0; i < Inventory.InventoryList.Count; i++)
            {
                BoxList[i].Image = Inventory.InventoryList[i].Token.Bitmap;
                BoxList[i].BackColor = Color.Transparent;
                LabelList[i].Text = Inventory.InventoryList[i].Name;
            }
        }
        #endregion

        #region Item Use
        private void PictureBox_Select(object sender, EventArgs e)
        {
            selected = (PictureBox)sender;
            RemoveItem();
        }

        private void RemoveItem()
        {
            for (int i = 0; i < BoxList.Count; i++)
            {
                if (selected == BoxList[i] && BoxList[i].Image != null)
                {
                    Inventory.InventoryList[i].UseItem();
                    Inventory.InventoryList[i].Token.Dispose();
                    Inventory.InventoryList[i].IsDead = true;
                    Inventory.InventoryList.RemoveAt(i);
                    BoxList[i].Image = null;
                    LabelList[i].Text = null;
                    UpdateItems();
                }
            }
        }
        #endregion
        #endregion
    }
}