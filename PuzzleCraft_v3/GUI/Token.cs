using PuzzleCraft_v3.Classes;
using PuzzleCraft_v3.Classes.Items;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PuzzleCraft_v3.GUI
{
    /*
     Token will face right by default when not moving
     */

    public partial class Token : UserControl
    {
        private BaseCharacter _Character;
        private Bitmap _Bitmap;
        private ProgressBar HealthBar;
        private PictureBox PicBox;
        private Point StartPoint;
        private bool _IsMonster;
        private static Random rnd = new Random();
        private double _startX;
        private double _startY;
        private float Angle;

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
        { get;set;
            //get { return _startX; }
            //set
            //{
            //    if(_Character is Player)
            //    {
            //        if (value + this.Width > Main.MainForm?.ClientSize.Width)
            //            _startX = (int)Main.MainForm?.ClientSize.Width - this.Width;
            //        else
            //            _startX = value;
            //    }
            //    else if (_Character is Monster)
            //    {
            //        _startX = value;
            //    }
            //    //else
            //    //    _startX = value;
            //}
        }
        public double LocY
        {
            get; set;
            //get { return _startY; }
            //set
            //{
            //    if (_Character is Player)
            //    {
            //        if (value + this.Height > Main.MainForm?.ClientSize.Height)
            //            _startY = (int)Main.MainForm?.ClientSize.Height - this.Height;
            //        else
            //            _startY = value;
            //    }
            //    else if(_Character is Monster)
            //    {
            //        _startY = value;
            //    }
            //    //else
            //    //    _startY = value;
            //}
        }

        public Bitmap Bitmap
        {
            get { return _Bitmap; }
        }
        #endregion

        public Token(BaseCharacter character)
        {
            InitializeComponent();
            _Character = character;
            _IsMonster = _Character.IsMonster;
            //Transparent background breaks the game?
            StartPoint = SpawnLocation(_Character.TokenSize);
            _startX = StartPoint.X;
            _startY = StartPoint.Y;
            _Bitmap = _Character.Bitmap;
            this.Top = (int)_startY;
            this.Left = (int)_startX;
            this.Size = _Character.TokenSize;
            SetUpPicture(_Character);
            Main.MainForm?.Controls.Add(this);
        }

        public Token(Item item)
        {
            InitializeComponent();
            StartPoint = SpawnLocation(item.TokenSize);
            _startX = StartPoint.X;
            _startY = StartPoint.Y;
            _Bitmap = item.Bitmap;
            this.Top = (int)_startY;
            this.Left = (int)_startX;
            this.Size = item.TokenSize;
            SetUpPicture(item);
            Main.MainForm?.Controls.Add(this);
        }

        public static Point SpawnLocation(Size newMonster)
        {
            Point spawnPoint = new(rnd.Next(0, Main.MainForm.ClientSize.Width - newMonster.Width),
                                        rnd.Next(0, Main.MainForm.ClientSize.Height - newMonster.Height));
            return spawnPoint;
        }

        public void UpdateTokenHP(int damage)
        {
            if (damage > HealthBar.Value)
                HealthBar.Value = 0;
            else
                HealthBar.Value -= damage;
        }

        public void UpdatePictureDirection(BaseCharacter tmp, float angle)
        {
            Angle = angle;
            this.Invalidate(false);
        }

        private void SetUpPicture(BaseCharacter character)
        {
            PicBox = new();
            PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PicBox.Image = character.Bitmap;
            PicBox.Size = new Size((int)Math.Round(character.TokenSize.Width / 1.05), (int)Math.Round(character.TokenSize.Height / 1.05));
            PicBox.Location = new Point(character.TokenSize.Width / 2 - PicBox.Width / 2, character.TokenSize.Height / 2 - PicBox.Height / 2);
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
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(img, new Point(0, 0));
            gfx.Dispose();
            return bmp;
        }

        private void Token_Paint(object sender, PaintEventArgs e)
        {
            Image tmpImage;
            tmpImage = RotateImage(_Bitmap, Angle + 90);
            PicBox.Image = tmpImage;
        }
    }
}