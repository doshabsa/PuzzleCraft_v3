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
        public double stepX;
        public double stepY;
        public double LocX;
        public double LocY;

        public Token(Bitmap pic, Point loc, Size newSize)
        {
            InitializeComponent();
            LocX = loc.X;
            LocY = loc.Y;
            this.Top = loc.Y;
            this.Left = loc.X;
            this.Size = newSize;
            SetUpPicture(pic);
            BaseChar.MainForm?.Controls.Add(this);
            BaseChar.TokenList.Add(this);
        }

        private void SetUpPicture(Bitmap pic)
        {
            PictureBox picture = new();
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Image = pic;
            picture.Size = this.Size;
            this.Controls.Add(picture);
        }
    }
}
