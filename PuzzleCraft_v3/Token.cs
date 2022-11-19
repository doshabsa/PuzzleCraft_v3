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
        private Bitmap _picture;
        public PictureBox _box;
        private ProgressBar _bar;

        private double NewAngleMarker;
        private double OldAngleMarker;
        public float Angle;

        public Token(Bitmap pic, Size newSize, Point loc, int hp)
        {
            InitializeComponent();
            this.Size = newSize;
            LocX = loc.X - this.Size.Width/2;
            LocY = loc.Y - this.Size.Height/2;
            this.Top = (int)LocY;
            this.Left = (int)LocY;
            _picture = pic;
            SetUpPicture(_picture, hp);
            BaseChar.MainForm?.Controls.Add(this);
        }

        private void SetUpPicture(Bitmap pic, int hp)
        {
            _box = new();
            _box.SizeMode = PictureBoxSizeMode.StretchImage;
            _box.Image = pic;
            _box.Size = this.Size;
            this.Controls.Add(_box);

            _bar = new ProgressBar();
            _bar.Height = 3;
            _bar.Maximum = hp;
            _bar.Value = hp;
            this.Controls.Add(_bar);
            _bar.BringToFront();
        }

        public void UpdateTokenHP(int damage)
        {
            _bar.Value -= damage;
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
            tmpImage = RotateImage(_picture, Angle+90);
            _box.Image = tmpImage;
            //OldAngleMarker = NewAngleMarker;
        }
    }
}
