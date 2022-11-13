using PuzzleCraft_v3.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleCraft_v3
{
    internal partial class Backpack : UserControl
    {
        private Panel FullBag;
        private Panel ClosedBag;
        private Label Opened;
        private Label Closed;

        public Backpack()
        {
            this.Size = new Size(380, 210);
            this.BackColor = Color.DarkGoldenrod;
            SetUpPack();
            this.Location = new Point(100, 100);
            BaseChar.MainForm?.Controls.Add(this);
        }

        private void SetUpPack()
        {
            this.Font = new Font("Arial", 12);
            this.BackColor = Color.Transparent;

            FullBag = new()
            {
                Location = new Point(3, 3),
                Size = new Size(this.Width - 6, this.Height - 6),
                Name = "pnlBagOpen",
                BackColor = Color.OldLace
            };
            this.Controls.Add(FullBag);

            Opened = new();
            Opened.Location = new Point(FullBag.Width / 2 - Opened.Width / 2, 3);
            Opened.Name = "lblOpenBag";
            Opened.Text = "Backpack:";
            Opened.BackColor = Color.OldLace;
            Opened.Font = new Font(this.Font, FontStyle.Bold);
            Opened.ForeColor = Color.Black;
            Opened.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(Opened);
            Opened.BringToFront();

            //ClosedBag = new()
            //{
            //    Location = new Point(3, 3),
            //    Size = new Size(30, 15),
            //    Name = "pnlBagClosed",
            //    BackColor = Color.OldLace,
            //    Visible = true
            //};

            //Closed = new();
            //Closed.Location = new Point(ClosedBag.Width / 2 - Closed.Width / 2, 0);
            //Closed.Name = "lblCloseBag";
            //Closed.ForeColor = Color.Black;
            //Closed.Font = new Font(this.Font, FontStyle.Bold);
            //ClosedBag.Controls.Add(Closed);

            //ClosedBag.Controls.Add(ClosedBag);

            //Code to prompt item slots
        }

        public static void GameReset()
        {
            //Code to reset all items in the pack
        }

        private static void AlterInventory(string ItemName, int Value, bool AddOrRemove)
        {
            //Code to add or remove from the pack
        }
    }
}
