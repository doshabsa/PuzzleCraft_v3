using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleCraft_v3
{
    public partial class Token : UserControl
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Token(Bitmap pic, Point loc, Size newSize)
        {
            InitializeComponent();
            Y = loc.Y;
            X = loc.X;
            this.Top = Y;
            this.Left = X;
            this.Size = newSize;
            SetUpPicture(pic);
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
