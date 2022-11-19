using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static PuzzleCraft_v3.Classes.Player;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace PuzzleCraft_v3.Classes
{
    public abstract class BaseChar
    {
        #region Properties/Fields
        public Token Token;
        protected string CharName;
        protected bool isDead;
        protected double Speed;
        protected int HP;
        protected int Damage;
        public Point NewLocation;
        public Point OldLocation;

        public static Label newLabel;

        public static System.Windows.Forms.Timer? PlayerTimer = new();
        public static List<BaseChar> CharacterList = new();
        public static Main? MainForm;

        public int Health
        {
            get { return HP; }
            set
            {
                if (HP == 0) isDead = true;
                else if (value < 0) HP = 0;
                else HP = value;
            }
        }
        #endregion

        #region Constructors
        static BaseChar()
        {
            PlayerTimer.Interval = 5;
            PlayerTimer.Tick += PlayerTimer_Tick;
            PlayerTimer.Enabled = true;
        }

        public BaseChar(string name) //For Monsters and Items
        {
            isDead = false;
            CharName = name;
        }

        public BaseChar(Bitmap pic, string name) //For Player
        {
            isDead = false;
            CharName = name;
        }

        ~BaseChar()
        {

        }
        #endregion

        private static async void PlayerTimer_Tick(object? sender, EventArgs e)
        { 
            List<Task> Tasks = new();
            foreach (BaseChar c in CharacterList)
            {
                var tmp = new Task(() => c.RotateToken());
                Tasks.Add(tmp);
                tmp.Start();
            }
            await Task.WhenAll(Tasks.ToArray());

            foreach (BaseChar c in CharacterList)
            {
                c.MoveToken();
            }

            CheckForCrash();
            RemoveTheDead();

            if (CharacterList.Count < 2)
                Monster.CreateNewMonster();
        }

        #region Tick Events
        private bool hasValidPosition()
        {
            if (Token.Left - Token.Width > MainForm.ClientRectangle.Width
                || Token.Left < 0 - (Token.Width * 2))
                return false;
            if (Token.Top - Token.Height > MainForm.ClientRectangle.Height
                || Token.Top < 0 - (Token.Height * 2))
                return false;
            return true;
        }
        private static void RemoveTheDead()
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
        private static void CheckForCrash()
        {
            try
            {
                if (CharacterList.Count >= 2)
                    for (int i = 0; i < CharacterList.Count; i++)
                        for (int j = i; j < CharacterList.Count; j++)
                            if (i != j)
                                if (CrashTest(CharacterList[i], CharacterList[j]))
                                {
                                    CharacterList[i].AdvancedCollision(
                                        CharacterList[j].Damage, CharacterList[i]);
                                    CharacterList[j].AdvancedCollision(
                                        CharacterList[i].Damage, CharacterList[j]);
                                }
            }
            catch
            {

            }
        }

        private static bool CrashTest(BaseChar One, BaseChar Two)
        {
            if (One.Token.Left + One.Token.Width < Two.Token.Left) return false;
            if (Two.Token.Left + Two.Token.Width < One.Token.Left) return false;
            if (One.Token.Top + One.Token.Height < Two.Token.Top) return false;
            if (Two.Token.Top + Two.Token.Height < One.Token.Top) return false;
            return true;
        }

        private void AdvancedCollision(int damage, BaseChar otherGuy)
        {
            Health -= damage;
            if (Health <= 0) isDead = true;
            if (!isDead) Token.UpdateTokenHP(damage);
        }
        #endregion

        #region Movement
        private async Task RotateToken()
        {
            if (this is Player)
                await CalcTrajectory(Token.Left, Token.Top, NewLocation.X, NewLocation.Y);
            if (this is Monster && thePlayer is not null)
                await CalcTrajectory(Token.Left, Token.Top, thePlayer.Token.Left, thePlayer.Token.Top);

            Token.LocX += Token.StepX;
            Token.LocY += Token.StepY;
        }

        private void MoveToken()
        { //Issue with moving an image, since default origin is Top/Left. Need to move origin to centre.
            Token.Left = (int)Token.LocX - Token.Size.Width/2;
            Token.Top = (int)Token.LocY - Token.Size.Height/2;

            if (!hasValidPosition())
                isDead = true;
        }

        private async Task CalcTrajectory(int startX, int startY, int endX, int endY)
        {
            await Task.Run(() =>
            {
                double deltaX = endX - startX;
                double deltaY = endY - startY;
                double radians = Math.Atan2(deltaY, deltaX);
                double angle = radians * (180 / Math.PI);

                Token.UpdatePictureDirection(this, (float)angle);
                Token.StepX = Speed * Math.Cos(angle);
                Token.StepY = Speed * Math.Sin(angle);
            });
        }
        #endregion
    }
}
