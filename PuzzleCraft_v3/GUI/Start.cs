using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using PuzzleCraft_v3.Classes;

namespace PuzzleCraft_v3
{
    public partial class Start : UserControl
    {
        private const int NUMTOKENS = 32;
        private Random rnd = new Random();
        private Bitmap ChosenPic { get { return (Bitmap)selected.BackgroundImage; } }
        private static List<Bitmap> pcTokens = new();
        private static List<Bitmap> tokCopy = new();
        private static List<Panel> PanelList = new();
        private Panel? selected;

        public Start(Main mainForm)
        {
            InitializeComponent();
            Main.MainForm = mainForm;
            Player.PlayerTimer.Stop();
            this.Location = new Point(Main.MainForm.ClientSize.Width / 2 - this.Width / 2, Main.MainForm.ClientSize.Height / 2 - this.Height / 2);

            ResourceManager rm = Resource1.ResourceManager;
            for (int i = 0; i < NUMTOKENS; i++)
                pcTokens.Add((Bitmap)rm.GetObject("_" + i));

            SetUp(tplTable);

            RandomizeTok();
            Main.MainForm.Controls.Add(this);
        }

        private void SetUp(Control control)
        {
            foreach (Panel panel in control.Controls.OfType<Panel>())
                PanelList.Add(panel);
        }

        private void RandomizeTok()
        {
            tokCopy.Clear();
            foreach (Bitmap pic in pcTokens)
                tokCopy.Add(pic);

            for (int pb = 0; pb < PanelList.Count; pb++)
            {
                int selectImage = rnd.Next(0, tokCopy.Count);
                PanelList[pb].BackgroundImage = tokCopy[selectImage];
                tokCopy.RemoveAt(selectImage);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                Player newPlayer = new(ChosenPic, txtName.Text);
                this.Dispose();
            }
            else
                MessageBox.Show("Please select your character before starting the game.");
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            selected = null;
            UpdateTokens();
            RandomizeTok();
        }

        private void Panel_Select(object sender, EventArgs e)
        {
            selected = (Panel)sender;
            UpdateTokens();
        }

        private void UpdateTokens()
        {
            for (int i = 0; i < PanelList.Count; i++)
            {
                PanelList[i].BackColor = this.BackColor;
                if (selected == PanelList[i])
                    PanelList[i].BackColor = Color.White;
            }
        }
    }
}