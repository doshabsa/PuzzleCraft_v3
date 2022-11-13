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
        private static Panel OpenedBag;
        private static Panel ClosedBag;
        private static Label lblOpenBag;
        private static Label lblCloseBag;
        private static Size lblOpenBagSize = new Size(380, 210);
        private static Size ClosedSize = new Size(110, 30);

        public Backpack()
        {
            this.Font = new Font("Arial", 12);
            this.Size = lblOpenBagSize;
            this.Location = new Point(3, 3);
            this.BackColor = Color.Transparent;

            SetupOpenBag();
            SetupCloseBag();
            BaseChar.MainForm?.Controls.Add(this);
        }

        private void ToggleBag_Click(object? sender, EventArgs e)
        {
            if (lblOpenBag.Visible)
            {
                BaseChar.PlayerTimer.Start();
                this.Size = ClosedSize;
                OpenedBag.Visible = false;
                lblOpenBag.Visible = false;
                ClosedBag.Visible = true;
                lblCloseBag.Visible = true;
                lblCloseBag.BringToFront();
            }
            else
            {
                BaseChar.PlayerTimer.Stop();
                this.Size = lblOpenBagSize;
                OpenedBag.Visible = true;
                lblOpenBag.Visible = true;
                ClosedBag.Visible = false;
                lblCloseBag.Visible = false;
                lblOpenBag.BringToFront();
            }
        }

        private void SetupCloseBag()
        {
            ClosedBag = new()
            {
                Size = ClosedSize,
                Name = "pnlBagClose",
                BackColor = Color.OldLace,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Left | AnchorStyles.Top//,
                //Dock = DockStyle.Fill
            };
            this.Controls.Add(ClosedBag);

            lblCloseBag = new();
            lblCloseBag.Location = new Point(ClosedBag.Width / 2 - lblCloseBag.Width / 2, 4);
            lblCloseBag.Name = "lblCloseBag";
            lblCloseBag.Text = "Backpack";
            lblCloseBag.BackColor = Color.OldLace;
            lblCloseBag.Font = new Font(this.Font, FontStyle.Bold);
            lblCloseBag.ForeColor = Color.DarkGoldenrod;
            lblCloseBag.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblCloseBag);
            lblCloseBag.Click += ToggleBag_Click;
            lblCloseBag.BringToFront();
        }

        private void SetupOpenBag()
        {
            OpenedBag = new()
            {
                Size = new Size(this.Width - 6, this.Height - 6),
                Name = "pnlBagOpen",
                BackColor = Color.OldLace,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false,
                Anchor = AnchorStyles.Left | AnchorStyles.Top//,
                //Dock = DockStyle.Fill
            };
            this.Controls.Add(OpenedBag);

            lblOpenBag = new();
            lblOpenBag.Location = new Point(OpenedBag.Width / 2 - lblOpenBag.Width / 2, 4);
            lblOpenBag.Name = "lblOpenBag";
            lblOpenBag.Text = "Backpack";
            lblOpenBag.BackColor = Color.OldLace;
            lblOpenBag.Font = new Font(this.Font, FontStyle.Bold);
            lblOpenBag.ForeColor = Color.DarkGoldenrod;
            lblOpenBag.TextAlign = ContentAlignment.MiddleCenter;
            lblOpenBag.Visible = false;
            this.Controls.Add(lblOpenBag);
            lblOpenBag.Click += ToggleBag_Click;
            lblOpenBag.BringToFront();
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
