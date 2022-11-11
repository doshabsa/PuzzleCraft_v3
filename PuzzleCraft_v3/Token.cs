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
        public Token(Bitmap pic, Point loc, Size newSize)
        {
            InitializeComponent();
            this.Top = loc.Y;
            this.Left = loc.X;
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

        public static void MoveTop(BaseChar character, bool dir)
        {
            if (dir)
                character.Token.Top -= character.Speed;
            else
                character.Token.Top += character.Speed;
            if (character.Token.Top < 0) character.Token.Top = 0;
            if (character.Token.Top + character.Token.Height > BaseChar.MainForm?.Height) character.Token.Top = BaseChar.MainForm.Height - character.Token.Height;
        }

        public static void MoveLeft(BaseChar character, bool dir)
        {
            if (dir)
                character.Token.Left -= character.Speed;
            else
                character.Token.Left += character.Speed;
            if (character.Token.Left < 0) character.Token.Left = 0;
            if (character.Token.Left + character.Token.Width > BaseChar.MainForm?.Width) character.Token.Left = BaseChar.MainForm.Width - character.Token.Width;
        }
    }
}
