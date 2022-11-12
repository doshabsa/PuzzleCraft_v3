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
    public class Player : BaseChar
    {
        #region Properties/Fields
        public static Player? thePlayer;
        public static Point NewLocation;
        #endregion

        #region Constructors
        public Player(Bitmap pic, string name, Point loc, Size size) : base(pic, name)
        {
            isDead = false;
            HP = 100;
            Speed = 1;
            Damage = 5;
            thePlayer = this;
            Token = new(pic, size, loc, HP);
            BaseChar.CharacterList.Add(this);
        }
        #endregion

        #region Methods
        public override void T1_Tick(object? sender, EventArgs e)
        {
            base.T1_Tick(sender, e);
            CalcTrajectory(Token.Left, Token.Top, NewLocation.X, NewLocation.Y);
        }

        protected virtual void CalcTrajectory(int startX, int startY, int endX, int endY)
        {
            double deltaX = endX - startX;
            double deltaY = endY - startY;
            double angle = Math.Atan2(deltaY, deltaX);

            Token.stepX = Speed * Math.Cos(angle);
            Token.stepY = Speed * Math.Sin(angle);
        }
        #endregion
    }
}
