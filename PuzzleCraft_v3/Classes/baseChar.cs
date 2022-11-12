using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static PuzzleCraft_v3.Classes.Player;
using static System.Windows.Forms.AxHost;

namespace PuzzleCraft_v3.Classes
{
    public class BaseChar
    {
        #region Properties/Fields
        public Token Token;
        protected string CharName;
        protected bool isDead;
        protected bool isSmart;
        protected double Speed;
        protected int HP;
        protected int Damage;
        protected static System.Windows.Forms.Timer? PlayerTimer;

        public static List<BaseChar> CharacterList = new();
        public static Main? MainForm;

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
        public Point GetLocation { get { return Token.Location; } }
        public Size GetDimensions { get { return Token.Size; } }
        public bool IsDead { get { return isDead; } }
        #endregion

        #region Constructors
        public BaseChar(string name) //For Monsters and Items
        {
            CharName = name;
        }

        public BaseChar(Bitmap pic, string name) //For Player
        {
            CharName = name;
        }

        ~BaseChar()
        {

        }
        #endregion

        public virtual void PlayerTimer_Tick(object? sender, EventArgs e)
        {
            Move();
            if (isSmart)
            {
                if (this is Monster)
                    CalcTrajectory(Token.Left, Token.Top, thePlayer.Token.Left, thePlayer.Token.Top);
                else
                    CalcTrajectory(Token.Left, Token.Top, NewLocation.X, NewLocation.Y);
            }
            CheckForCrash();
            RemoveTheDead();
        }

        #region Tick Events
        public virtual void Move()
        {
            foreach (BaseChar c in CharacterList)
            {
                c.Token.LocX += c.Token.StepX;
                c.Token.LocY += c.Token.StepY;
                c.Token.Left = (int)c.Token.LocX;
                c.Token.Top = (int)c.Token.LocY;
            }

            if (!this.hasValidPosition())
                this.isDead = true;
        }

        protected virtual void CalcTrajectory(int startX, int startY, int endX, int endY)
        {
            double deltaX = endX - startX;
            double deltaY = endY - startY;
            double angle = Math.Atan2(deltaY, deltaX);

            Token.StepX = Speed * Math.Cos(angle);
            Token.StepY = Speed * Math.Sin(angle);
        }

        public static void CheckForCrash()
        {
            try
            {
                if (CharacterList.Count >= 2)
                    for (int i = 0; i < CharacterList.Count; i++)
                        for (int j = i; j < CharacterList.Count; j++)
                            if (i != j)
                                if (CrashTest(CharacterList[i], CharacterList[j]))
                                {
                                    CharacterList[i].AdvancedCollision(CharacterList[j].Damage, CharacterList[i]);
                                    CharacterList[j].AdvancedCollision(CharacterList[i].Damage, CharacterList[j]);
                                }
            }
            catch
            {

            }
        }

        public static void RemoveTheDead()
        {
            List<int> isDeadList = new();
            for (int i = 0; i < CharacterList.Count; i++)
                if (CharacterList[i].isDead) isDeadList.Add(i);

            for (int i = 0; i < isDeadList.Count; i++)
            {
                MainForm.Controls.Remove(CharacterList[isDeadList[i] - i].Token);
                CharacterList[isDeadList[i] - i].Token.Dispose();
                CharacterList.RemoveAt(isDeadList[i] - i);
            }
        }
        #endregion

        #region Collision
        private static bool CrashTest(BaseChar One, BaseChar Two)
        {
            if (One.Token.Left + One.Token.Width < Two.Token.Left) return false;
            if (Two.Token.Left + Two.Token.Width < One.Token.Left) return false;
            if (One.Token.Top + One.Token.Height < Two.Token.Top) return false;
            if (Two.Token.Top + Two.Token.Height < One.Token.Top) return false;
            return true;
        }

        public void AdvancedCollision(int damage, BaseChar otherGuy)
        {
            Health -= damage;
            if (Health <= 0) isDead = true;
            if (!isDead) Token.UpdateTokenHP(damage);
        }
        #endregion

        #region Movement
        public bool hasValidPosition()
        {
            if (Token.Left + Token.Width > MainForm.ClientRectangle.Width || Token.Left < 0 - Token.Width)
                return false;
            if (Token.Top + Token.Height > MainForm.ClientRectangle.Height || Token.Top < 0 - Token.Height)
                return false;
            return true;
        }
        #endregion
    }
}
