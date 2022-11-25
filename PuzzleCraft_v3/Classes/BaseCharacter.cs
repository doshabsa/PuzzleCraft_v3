using System;
using System.Collections.Generic;
using PuzzleCraft_v3.Classes.Monsters;
using static PuzzleCraft_v3.Classes.Player;

namespace PuzzleCraft_v3.Classes
{
    public abstract class BaseCharacter
    {
        #region Properties/Fields
        public Token Token;
        protected string? CharName;
        protected bool isSmart;
        protected bool canMove;
        protected bool isDead;
        protected double Speed;
        protected int HP;
        protected int Damage;

        public static System.Windows.Forms.Timer? PlayerTimer = new();
        public static List<BaseCharacter> CharacterList = new();
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
        static BaseCharacter()
        {
            PlayerTimer.Interval = 5;
            PlayerTimer.Tick += PlayerTimer_Tick;
            PlayerTimer.Enabled = true;
        }

        public BaseCharacter(string name) //For Monsters and Items
        {
            isDead = false;
            CharName = name;
        }

        public BaseCharacter(Bitmap pic, string name) //For Player
        {
            isDead = false;
            CharName = name;
        }
        #endregion

        private static async void PlayerTimer_Tick(object? sender, EventArgs e)
        {
            List<Task> Tasks = new();
            foreach (BaseCharacter c in CharacterList)
            {
                if (c.isSmart)
                {
                    var tmp = new Task(() => c.RotateToken());
                    Tasks.Add(tmp);
                    tmp.Start();
                }
            }

            await Task.WhenAll(Tasks.ToArray());

            foreach (BaseCharacter c in CharacterList)
            {
                if(c.canMove)
                    c.Move();
            }

            CheckForCrash();
            RemoveTheDead();

            if (CharacterList.Count < 2)
                Monster.CreateNewMonster();
        }

        #region Tick Events
        private bool hasValidPosition()
        {
            if (Token.Left - Token.Width > MainForm?.ClientSize.Width
                || Token.Left < 0)
                return false;
            if (Token.Top - Token.Height > MainForm?.ClientSize.Height
                || Token.Top < 0)
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
            catch { }
        }

        private static bool CrashTest(BaseCharacter One, BaseCharacter Two)
        {
            if (One.Token.Left + One.Token.Width < Two.Token.Left) return false;
            if (Two.Token.Left + Two.Token.Width < One.Token.Left) return false;
            if (One.Token.Top + One.Token.Height < Two.Token.Top) return false;
            if (Two.Token.Top + Two.Token.Height < One.Token.Top) return false;
            return true;
        }

        private void AdvancedCollision(int damage, BaseCharacter otherGuy)
        {
            Health -= damage;
            if (!isDead) Token?.UpdateTokenHP(damage);
        }
        #endregion

        #region Movement
        protected virtual void Move()
        {
            Token.LocX += Token.StepX;
            Token.LocY += Token.StepY;
            Token.Left = (int)Token.LocX;
            Token.Top = (int)Token.LocY;

            if (!hasValidPosition())
                isDead = true;
        }

        private async Task RotateToken()
        {
            if (this is Player)
                await CalcTrajectory(Token.Left, Token.Top, thePlayer.ClickLocation.X, thePlayer.ClickLocation.Y);
            if (this is Monster && thePlayer is not null)
                await CalcTrajectory(Token.Left, Token.Top, thePlayer.Token.Left, thePlayer.Token.Top);
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
                Token.StepX = Speed * Math.Cos(radians);
                Token.StepY = Speed * Math.Sin(radians);
            });
        }
        #endregion
    }
}
