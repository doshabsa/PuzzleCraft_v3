using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v3.Classes
{
    internal class BaseChar
    {
        #region Properties/Fields
        protected bool isDead;
        protected PictureBox picture = new();
        public static Main? mainForm;

        protected int HP;
        public int Health
        {
            get { return HP; }
            set
            {
                if (value < 0) HP = 0;
                else if (HP == 0) isDead = true;
                else HP = value;
            }
        }
        public Point Location { get { return picture.Location; } }
        public Size Dimensions { get { return picture.Size; } }
        public bool IsDead {  get { return isDead; } }
        #endregion

        #region Constructors
        public BaseChar(Bitmap pic, Point loc, Size size)
        {
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Image = pic;
            picture.Size = size;
            picture.Location = loc;
            mainForm?.Controls.Add(picture);
        }
        #endregion

        #region Methods
        public virtual void Deletion()
        {
            mainForm?.Controls.Remove(picture);
        }
        #endregion
    }
}
