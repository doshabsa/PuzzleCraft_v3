using PuzzleCraft_v3.Classes;
using PuzzleCraft_v3.Classes.Items;
using System.Windows.Forms;

namespace PuzzleCraft_v3.GUI
{
    public partial class Backpack : UserControl
    {
        #region Controls
        private static Panel ClosedBag;
        private static Label lblCloseBag;
        private static Size ClosedSize = new Size(110, 30);
        private static Point ClosedBackpackDock = new Point(3, 3);
        private static List<PictureBox> BoxList;
        #endregion

        static Backpack()
        {
            BoxList = new();
        }

        #region Constructor
        public Backpack()
        {
            InitializeComponent();
            this.Font = new Font("Arial", 12);
            SetupBoxList(tlpTable);
            SetupCloseBag();
            this.Visible = false;
            this.Location = ClosedBackpackDock;
            Main.MainForm?.Controls.Add(this);
        }
        #endregion

        #region Methods

        #region Controls
        private void ToggleBag_Click(object? sender, EventArgs e)
        {
            if (Player.PlayerTimer?.Enabled == true)
            {
                this.Show();
                Player.PlayerTimer.Stop();
                ClosedBag.Hide();
                this.BringToFront();
            }
            else
            {
                Player.PlayerTimer.Start();
                this.Hide();
                ClosedBag.Show();
                ClosedBag.BringToFront();
            }
        }

        private void SetupCloseBag()
        {
            ClosedBag = new()
            {
                Location = ClosedBackpackDock,
                Size = ClosedSize,
                Name = "pnlBagClose",
                BackColor = Color.OldLace,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Left | AnchorStyles.Bottom
            };
            Main.MainForm.Controls.Add(ClosedBag);

            lblCloseBag = new();
            lblCloseBag.Location = new Point(ClosedBag.Width / 2 - lblCloseBag.Width / 2, 4);
            lblCloseBag.Name = "lblCloseBag";
            lblCloseBag.Text = "Backpack";
            lblCloseBag.BackColor = Color.OldLace;
            lblCloseBag.Font = new Font(this.Font, FontStyle.Bold);
            lblCloseBag.ForeColor = Color.DarkGoldenrod;
            lblCloseBag.TextAlign = ContentAlignment.MiddleCenter;
            ClosedBag.Controls.Add(lblCloseBag);
            lblCloseBag.Click += ToggleBag_Click;
        }

        private void SetupBoxList(Control control)
        {
            foreach (PictureBox pic in control.Controls.OfType<PictureBox>())
            {
                BoxList.Add(pic);
            }
        }

        #endregion

        #region Item Display
        public static void RemoveUsedItems()
        {
            foreach(Item i in Inventory.InventoryList)
            {
                if (i.IsDead)
                {
                    Inventory.InventoryList.Remove(i);
                    i.Token.Dispose();
                }
            }
        }

        private static void UpdateImages()
        {
            for(int i = 0; i < Inventory.InventoryList.Count; i++)
            {
                
            }
        }
        #endregion
        #endregion
    }
}
