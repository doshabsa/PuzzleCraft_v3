using PuzzleCraft_v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PuzzleCraft_v3.Classes.BaseChar;
using static System.Windows.Forms.AxHost;

namespace PuzzleCraft_v3.Classes
{
    internal class Player : BaseChar
    {
        #region Properties/Fields
        public static Point NewLocation;
        public static Player thePlayer;
        #endregion

        #region Constructors
        public Player(Bitmap pic, string name, Point loc, Size size) : base(pic, name)
        {
            thePlayer = this;
            isDead = false;
            isSmart = true;
            HP = 100;
            Speed = 1;
            Damage = 5;
            Token = new(pic, size, loc, HP);
            BaseChar.CharacterList.Add(this);
            PlayerTimer = new System.Windows.Forms.Timer();
            PlayerTimer.Interval = 5;
            PlayerTimer.Tick += PlayerTimer_Tick;
            PlayerTimer.Enabled = true;
        }
        #endregion

        #region Methods

        #endregion
    }
}
