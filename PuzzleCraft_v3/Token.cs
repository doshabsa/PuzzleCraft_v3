using Microsoft.VisualBasic.Logging;
using PuzzleCraft_v3.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace PuzzleCraft_v3
{
    public partial class Token : UserControl
    {
        public double StepX { get; set; }
        public double StepY { get; set; }
        public double LocX { get; set; }
        public double LocY { get; set; }

        private List<Bitmap> TokenPictures = new();

        //private Graphics Graphic;
        private Bitmap Bitmap;
        public PictureBox PicBox;
        private ProgressBar ProgressBar;

        public Token(Bitmap pic, Size newSize, Point loc, int hp)
        {
            InitializeComponent();
            if (TokenPictures.Count < 8)   //Checks if a playerImages list is already made
            {
                for (int i = 0; i < 8; i++) //Adds eight player tokens to playerImages List
                    TokenPictures.Add(new Bitmap(pic));
                SetupTokenList(); //Adjusts images to complete players laying in all four directions (plus flipped versions)
            }
            LocX = loc.X;
            LocY = loc.Y;
            this.Top = loc.Y;
            this.Left = loc.X;
            this.Size = newSize;
            //Graphic = Graphics.FromImage(pic);
            Bitmap = pic;
            SetUpPicture(Bitmap, hp);
            BaseChar.MainForm?.Controls.Add(this);
        }

        private void SetupTokenList()
        {
            TokenPictures[1].RotateFlip(RotateFlipType.Rotate90FlipNone);
            TokenPictures[2].RotateFlip(RotateFlipType.Rotate180FlipNone);
            TokenPictures[3].RotateFlip(RotateFlipType.Rotate270FlipNone);
            TokenPictures.Add(Resource1.skeleton);
        }

        private void SetUpPicture(Bitmap pic, int hp)
        {
            PicBox = new();
            PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PicBox.Image = pic;
            PicBox.Size = this.Size;
            this.Controls.Add(PicBox);

            ProgressBar = new ProgressBar();
            ProgressBar.Height = 3;
            ProgressBar.Maximum = hp;
            ProgressBar.Value = hp;
            this.Controls.Add(ProgressBar);
            ProgressBar.BringToFront();
        }

        public void UpdateTokenHP(int damage)
        {
            ProgressBar.Value -= damage;
        }

        public void UpdatePictureDirection(double angle)
        {
            ////Graphic.TranslateTransform(startX, startY);
            //Graphic.RotateTransform((float)angle, MatrixOrder.Append);
            ////Graphic.TranslateTransform((float)angle, startY, MatrixOrder.Append);

            //Bitmap = new Bitmap(PicBox.Width, PicBox.Height, Graphic);
            //PicBox.Image = Bitmap;

            //switch (angle)
            //{
            //    case 0: //Up
            //        PicBox.Image = TokenPictures[0];
            //        break;
            //    case 1: //Up-right
            //        PicBox.Image = TokenPictures[1];
            //        break;
            //    case 2: //Right
            //        PicBox.Image = TokenPictures[2];
            //        break;
            //    case 3: //Down-right
            //        PicBox.Image = TokenPictures[3];
            //        break;
            //    case 4: //Down
            //        PicBox.Image = TokenPictures[4];
            //        break;
            //    case 5: //Down-left
            //        PicBox.Image = TokenPictures[5];
            //        break;
            //    case 6: //Left
            //        PicBox.Image = TokenPictures[6];
            //        break;
            //    case 7: //Up-left
            //        PicBox.Image = TokenPictures[7];
            //        break;
            //}

        }
    }
}
