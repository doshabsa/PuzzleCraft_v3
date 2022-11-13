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
        private static List<Bitmap> pcTokens = new(NUMTOKENS);
        private static List<Bitmap> tokCopy = new List<Bitmap>();
        private PictureBox[] boxes = new PictureBox[6];
        private Panel[] backings = new Panel[6];
        private PictureBox? selected;

        public Start()
        {
            InitializeComponent();

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
            BaseChar.MainForm.Controls.Add(this);
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
                Player newPlayer = new((Bitmap)selected.Image, txtName.Text, selected.Location, selected.Size);
                Monster newMonster = new("raven");
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