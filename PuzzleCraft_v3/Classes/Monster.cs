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
            (int, Bitmap?, Size, Point) details = GetMonsterDetails(name);
            HP = details.Item1;
            Token = new(details.Item2, details.Item4, details.Item3);
            BaseChar.CharacterList.Add(this);
        }
        #endregion

        #region Methods
        private (int, Bitmap?, Size, Point) GetMonsterDetails(string name) //There is a better way, this works for now
        {
            switch (name)
            {
                case "raven":
                    int tmpRavenSize = rnd.Next(25, 51);
                    Size ravenSize = new(tmpRavenSize, tmpRavenSize);
                    Point ravenPoint = new(rnd.Next(0, BaseChar.MainForm.Width - ravenSize.Width), rnd.Next(0, BaseChar.MainForm.Height - ravenSize.Height));
                    var raven = (1, new Bitmap(Resource1.raven), ravenSize, ravenPoint);
                    return raven;

                case "stick":
                    int tmpStickSize = rnd.Next(10, 31);
                    Size stickSize = new(tmpStickSize, tmpStickSize);
                    Point stickPoint = new(rnd.Next(0, BaseChar.MainForm.Width - stickSize.Width), rnd.Next(0, BaseChar.MainForm.Height - stickSize.Height));
                    var stick = (1, new Bitmap(Resource1.stick), stickSize, stickPoint);
                    return stick;

                default: //change default image?
                    Size newSize = new(25, 25);
                    Point newPoint = new(rnd.Next(0, BaseChar.MainForm.Width - newSize.Width), rnd.Next(0, BaseChar.MainForm.Height - newSize.Height));
                    var n = (10, new Bitmap(Resource1.raven), newSize, newPoint);
                    return n;
            } 
        }
        #endregion
    }
}
