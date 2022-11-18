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
using System.Drawing;
using System.Windows.Forms;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace PuzzleCraft_v3
{
    public partial class Token : UserControl
    {
        public double StepX { get; set; }
        public double StepY { get; set; }
        public double LocX { get; set; }
        public double LocY { get; set; }

        //private List<Bitmap> TokenPictures = new();

        //private Graphics Graphic;
        private Bitmap Bitmap;
        public PictureBox PicBox;
        private ProgressBar ProgressBar;

        private double NewAngleMarker;
        private double OldAngleMarker;
        public float Angle;

        public Token(Bitmap pic, Size newSize, Point loc, int hp)
        {
            InitializeComponent();
            LocX = loc.X;
            LocY = loc.Y;
            this.Top = loc.Y;
            this.Left = loc.X;
            this.Size = newSize;
            Bitmap = pic;
            SetUpPicture(Bitmap, hp);
            BaseChar.MainForm?.Controls.Add(this);
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

        public static System.Drawing.Image RotateImage(System.Drawing.Image img, float rotationAngle)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(img, new Point(0, 0));
            gfx.Dispose();
            return bmp;
        }

        public void UpdatePictureDirection(BaseChar tmp, float angle)
        {
            Angle = angle;
            //NewAngleMarker = Math.Round(angle);
            this.Invalidate(false);
        }

        private void Token_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Image tmpImage;
            //await Task<System.Drawing.Image>.Run( () => 
            tmpImage = RotateImage(Bitmap, Angle+90);
            PicBox.Image = tmpImage;
            //OldAngleMarker = NewAngleMarker;
        }
    }
}
