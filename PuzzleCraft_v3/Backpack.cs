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
        private Panel panel;

        public Backpack()
        {
            this.Size = new Size(380, 210);
            this.BackColor = Color.DarkGoldenrod;
            SetUpPack();
            this.Location = new Point(100, 100);
            Player.mainForm.Controls.Add(this);
        }

        private void SetUpPack()
        {
            panel = new();
            panel.Location = new Point(3, 3);
            panel.Size = new Size(374, 204);
            panel.Name = "pnlBag";
            panel.BackColor = Color.OldLace;
            this.Controls.Add(panel);

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
