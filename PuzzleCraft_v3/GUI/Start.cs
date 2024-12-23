﻿using System.Resources;
using PuzzleCraft_v3.Classes;
using PuzzleCraft_v3.Classes.Monsters;
using PuzzleCraft_v3.Classes.Maps;
using PuzzleCraft_v3.Classes.Items;

namespace PuzzleCraft_v3
{
    public partial class Start : UserControl
    {
        public delegate void GameStatus();
        public GameStatus EndGame;

        private const int NUMTOKENS = 32;
        private Random rnd = new Random();
        private static List<Bitmap> pcTokens = new();
        private static List<Bitmap> tokCopy = new();
        private static List<PictureBox> BoxList = new();
        private PictureBox? selected;

        public Start()
        {
            InitializeComponent();
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
            foreach (PictureBox box in control.Controls.OfType<PictureBox>())
                BoxList.Add(box);
        }

        private void RandomizeTok()
        {
            tokCopy.Clear();
            foreach (Bitmap pic in pcTokens)
                tokCopy.Add(pic);

            for (int pb = 0; pb < BoxList.Count; pb++)
            {
                int selectImage = rnd.Next(0, tokCopy.Count);
                BoxList[pb].Image = tokCopy[selectImage];
                tokCopy.RemoveAt(selectImage);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                Player newPlayer = new((Bitmap)selected.Image, txtName.Text);
                newPlayer.EndGame += GameOver;
                Player.PlayerTimer.Stop();

                Raven m1 = new();

                _Map.Fetch();
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
            for (int i = 0; i < BoxList.Count; i++)
            {
                BoxList[i].BackColor = this.BackColor;
                if (selected == BoxList[i])
                    BoxList[i].BackColor = Color.White;
            }
        }

        private void GameOver()
        {
            _Character.CharacterList = null;
            Inventory.InventoryList = null;
            _Item.ItemList = null;
            EndGame();
        }
    }
}