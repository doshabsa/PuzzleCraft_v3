using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PuzzleCraft_v3.Classes
{
    internal class Monster : BaseChar
    {
        #region Properties/Fields
        private Random rnd = new Random();
        #endregion

        #region Constructors
        public Monster(string name) : base(name)
        {
            isDead = false;
            (int, double, int, Bitmap?, Size, Point) details = GetMonsterDetails(name);
            HP = details.Item1;
            Speed = details.Item2;
            Damage = details.Item3;
            Token = new(details.Item4, details.Item5, details.Item6, HP);
            BaseChar.CharacterList.Add(this);
            if (isSmart)
                PlayerTimer.Tick += PlayerTimer_Tick;
        }
        #endregion

        #region Methods
        private (int, double, int, Bitmap, Size, Point) GetMonsterDetails(string name) //There is a better way, this works for now
        {
            switch (name)
            {
                case "raven":
                    isSmart = true;
                    HP = 1;
                    Speed = 0.5;
                    Damage = 1;
                    Bitmap? ravenPic = Resource1.raven;
                    Size ravenSize = new(35, 35);
                    Point ravenPoint = new(rnd.Next(0, BaseChar.MainForm.Width - ravenSize.Width), rnd.Next(0, BaseChar.MainForm.Height - ravenSize.Height));
                    var raven = (HP, Speed, Damage, ravenPic, ravenSize, ravenPoint);
                    return raven;

                case "skeleton":
                    isSmart = false;
                    HP = 1;
                    Speed = 0;
                    Damage = 0;
                    Bitmap? skelePic = Resource1.skeleton;
                    Size skeleSize = new(35, 35);
                    Point skelePoint = new(rnd.Next(0, BaseChar.MainForm.Width - skeleSize.Width), rnd.Next(0, BaseChar.MainForm.Height - skeleSize.Height));
                    var skele = (HP, Speed, Damage, skelePic, skeleSize, skelePoint);
                    return skele;

                default: //change default image?
                    isSmart = false;
                    HP = 0;
                    Speed = 0;
                    Damage = 0;
                    Bitmap? newPic = null;
                    Size newSize = new(25, 25);
                    Point newPoint = new(rnd.Next(0, BaseChar.MainForm.Width - newSize.Width), rnd.Next(0, BaseChar.MainForm.Height - newSize.Height));
                    var n = (HP, Speed, Damage, newPic, newSize, newPoint);
                    return n;
            }
        }
        #endregion
    }
}
