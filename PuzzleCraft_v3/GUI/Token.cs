﻿using PuzzleCraft_v3.Classes;
using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.Classes.Monsters;
using System.Drawing.Drawing2D;

namespace PuzzleCraft_v3.GUI
{
    /*
    Token will face right by default when not moving
    */

    public partial class Token : UserControl
    {
        #region Fields
        private static Random rnd = new Random();

        private _Character _Character;
        private Bitmap _Bitmap;
        private ProgressBar HealthBar;
        private PictureBox PicBox;
        private Bitmap tmp;

        private double _startX;
        private double _startY;
        private float Angle;
        #endregion

        #region Public Propteries
        public double StepX
        {
            get;
            set;
        }
        public double StepY
        {
            get;
            set;
        }
        public double LocX
        {
            get { return _startX; }
            set
            {
                if (_Character is Player)
                {
                    if (value + this.Width > Main.MainForm?.ClientSize.Width)
                        this.Left = (int)Main.MainForm?.ClientSize.Width - this.Width;
                    else
                        this.Left = (int)value;
                }
                else if (_Character is _Monster)
                {
                    _startX = value;
                }
            }
        }
        public double LocY
        {
            get { return _startY; }
            set
            {
                if (_Character is Player)
                {
                    if (value + this.Height > Main.MainForm?.ClientSize.Height)
                        this.Left = (int)Main.MainForm?.ClientSize.Height - this.Height;
                    else
                        this.Left = (int)value;
                }
                else if (_Character is _Monster)
                {
                    _startY = value;
                }
            }
        }
        public Bitmap Bitmap
        {
            get
            {
                return _Bitmap;
            }
            set
            {
                if (_Character is Player)
                {
                    _Bitmap = value;
                    PicBox.Image = RotateImage(_Bitmap, Angle + 90);
                    Player.PlayerTimer.Stop();
                }
            }
        }
        public _Character Character
        {
            get { return _Character; }
        }
        #endregion

        #region Constructors
        public Token(_Character character)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            _Character = character;
            //Transparent background for the control breaks the game?
            //Attempted to use only picturebox, but had similar issues.
            //Also, a single picturebox didn't seem it as much warrented 
            //having its own class

            Point StartPoint = SpawnLocation(_Character.TokenSize);

            _startX = StartPoint.X;
            _startY = StartPoint.Y;
            _Bitmap = _Character.Bitmap;
            this.Top = (int)_startY;
            this.Left = (int)_startX;
            this.Size = _Character.TokenSize;

            SetUpPicture(_Character);

            if (character.IsSmart)
            {
                SpawnAngle();
                PicBox.Image = RotateImage(_Bitmap, Angle + 90);
                PicBox.Paint += PicBox_Paint;
            }

            Main.MainForm?.Controls.Add(this);
        }

        //Item spawn location is the same location as where a monster died, could 
        //possibly move certain treasures (or use for bombs?!)
        public Token(_Item item, Point location)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            _startX = location.X;
            _startY = location.Y;
            _Bitmap = item.Bitmap;
            this.Top = (int)_startY;
            this.Left = (int)_startX;
            this.Size = item.TokenSize;

            SetUpPicture(item);
            SpawnAngle();
            PicBox.Image = RotateImage(_Bitmap, Angle + 90);
            PicBox.Paint += PicBox_Paint;
            Main.MainForm?.Controls.Add(this);
        }

        //For treasure creation
        public Token(_Item item)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            _Bitmap = item.Bitmap;
            this.Size = item.TokenSize;

            SetUpPicture(item);
            SpawnAngle();
            PicBox.Image = RotateImage(_Bitmap, Angle + 90);
            PicBox.Paint += PicBox_Paint;
        }
        #endregion

        #region Randomizers
        //Monster and Player spawn locations are randomized
        public static Point SpawnLocation(Size newToken)
        {
            Point spawnPoint = new(rnd.Next(0, Main.MainForm.ClientSize.Width - newToken.Width),
                                        rnd.Next(0, Main.MainForm.ClientSize.Height - newToken.Height));
            return spawnPoint;
        }

        //Randomizes image angle at spawn
        private void SpawnAngle()
        {
            float tmp = rnd.Next(0, 360);
            if (tmp > 179)
                Angle = tmp / 2 * -1;
            else
                Angle = tmp;
            this.Invalidate(false);
        }
        #endregion

        #region Progress Bar
        public void UpdateTokenHP(_Character character)
        {
            if (character.Health > 0)
                HealthBar.Value = character.Health;
            else if (character.Health <= 0)
            {
                HealthBar.Value = 0;
                character.IsDead = true;
            }
        }
        #endregion

        #region Picturebox
        public void UpdatePictureDirection(float angle)
        {
            Angle = angle;
            PicBox.Image = tmp;
            if(PicBox.Image != null)
                PicBox.Invalidate(false);
        }

        private void SetUpPicture(_Character character)
        {
            PicBox = new();
            PicBox.BackColor = Color.Transparent;
            PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PicBox.Image = character.Bitmap;
            PicBox.Size = new Size((int)Math.Round(character.TokenSize.Width / 1.05),
                                        (int)Math.Round(character.TokenSize.Height / 1.05));
            PicBox.Location = new Point(character.TokenSize.Width / 2 - PicBox.Width / 2,
                                            character.TokenSize.Height / 2 - PicBox.Height / 2);
            this.Controls.Add(PicBox);

            HealthBar = new ProgressBar();
            HealthBar.Height = 3;
            HealthBar.Maximum = character.Health;
            HealthBar.Value = character.Health;
            this.Controls.Add(HealthBar);
            HealthBar.BringToFront();
        }

        private static Image RotateImage(Image img, float rotationAngle)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            //Transform is not -quite- right for all images
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(img, new Point(0, 0));
            gfx.Dispose();
            return bmp;
        }

        private void PicBox_Paint(object? sender, PaintEventArgs e)
        {
            if (Main.PlayGame && _Character is not Skeleton)
            {
                Image tmpImage;
                tmpImage = RotateImage(_Bitmap, Angle + 90);
                tmp = (Bitmap)tmpImage;
            }
        }
        #endregion
    }
}