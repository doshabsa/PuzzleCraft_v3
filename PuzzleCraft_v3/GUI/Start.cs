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
        private static List<Bitmap> pcTokens = new();
        private static List<Bitmap> tokCopy = new();
        private PictureBox[] boxes = new PictureBox[6];
        private Panel[] backings = new Panel[6];
        private PictureBox? selected;

        /*
            SetupBoxList(this);
    foreach (PictureBox pic in control.Controls.OfType<PictureBox>())
        boxes.Add(pic);

    foreach (Panel pnl in control.Controls.OfType<Panel>())
        panels.Add(pnl);

 */

        public Start(Main mainForm)
        {
            InitializeComponent();
            Main.MainForm = mainForm;
            Player.PlayerTimer.Stop();
            this.Location = new Point(Main.MainForm.ClientSize.Width/2 - this.Width/2, Main.MainForm.ClientSize.Height/2 - this.Height/2);
            
            ResourceManager rm = Resource1.ResourceManager;
            for (int i = 0; i < NUMTOKENS; i++)
                pcTokens.Add((Bitmap)rm.GetObject("_" + i));

            boxes[0] = pictureBox0;
            boxes[1] = pictureBox1;
            boxes[2] = pictureBox2;
            boxes[3] = pictureBox3;
            boxes[4] = pictureBox4;
            boxes[5] = pictureBox5;

            backings[0] = panel0;
            backings[1] = panel1;
            backings[2] = panel2;
            backings[3] = panel3;
            backings[4] = panel4;
            backings[5] = panel5;

            RandomizeTok();
            Main.MainForm.Controls.Add(this);
        }

        private void RandomizeTok()
        {
            tokCopy.Clear();
            foreach (Bitmap pic in pcTokens)
                tokCopy.Add(pic);

            for (int pb = 0; pb < boxes.Length; pb++)
            {
                int selectImage = rnd.Next(0, tokCopy.Count);
                boxes[pb].Image = tokCopy[selectImage];
                tokCopy.RemoveAt(selectImage);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                Player newPlayer = new((Bitmap)selected.Image, txtName.Text, new Point(100,100), selected.Size);
                Player.PlayerTimer.Start();
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

        private void PictureBox_Select(object sender, EventArgs e)
        {
            selected = (PictureBox)sender;
            UpdateTokens();
        }

        private void UpdateTokens()
        {
            for (int i = 0; i < 6; i++)
            {
                backings[i].BackColor = SystemColors.Control;
                if (selected == boxes[i])
                    backings[i].BackColor = Color.White;
            }
        }
    }
}