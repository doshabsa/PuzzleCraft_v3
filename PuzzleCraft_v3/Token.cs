using Microsoft.VisualBasic.Logging;
using PuzzleCraft_v3.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleCraft_v3
{
    public partial class Token : UserControl
    {
        public double StepX { get; set; }
        public double StepY { get; set; }
        public double LocX { get; set; }
        public double LocY { get; set; }

        private PictureBox picture;
        private ProgressBar progressBar;

        public Token(Bitmap pic, Size newSize, Point loc, int hp)
        {
            InitializeComponent();
            LocX = loc.X;
            LocY = loc.Y;
            this.Top = loc.Y;
            this.Left = loc.X;
            this.Size = newSize;
            SetUpPicture(pic, hp);
            BaseChar.MainForm?.Controls.Add(this);
        }

        private void SetUpPicture(Bitmap pic, int hp)
        {
            picture = new();
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Image = pic;
            picture.Size = this.Size;
            this.Controls.Add(picture);

            progressBar = new ProgressBar();
            progressBar.Maximum = hp;
            progressBar.Value = hp;
            progressBar.Height = 3;
            this.Controls.Add(progressBar);
            progressBar.BringToFront();
        }

        public void UpdateTokenHP(int damage)
        {
            progressBar.Value -= damage;
        }
    }
}
