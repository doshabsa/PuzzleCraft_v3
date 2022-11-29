using PuzzleCraft_v3.GUI;
using System;
using System.Collections.Generic;
using static PuzzleCraft_v3.Classes.Player;

namespace PuzzleCraft_v3.Classes
{
    public abstract class BaseCharacter
    {
        #region Properties
        protected Token _Token;
        protected Bitmap _Bitmap;
        protected Size _TokenSize;
        protected string? _Name;
        protected bool _IsSmart;
        protected bool _CanMove;
        protected bool _IsDead;
        protected double _Speed;
        protected int _HP;
        protected int _Damage;
        protected Backpack _Pack;

        protected static Random rnd = new Random();
        public static System.Windows.Forms.Timer? PlayerTimer = new();
        public static List<BaseCharacter> CharacterList = new();
        #endregion

        #region Public Properties
        public int Health
        {
            get { return _HP; }
            set
            {
                if (_HP <= 0) _IsDead = true;
                else if (value < 0) _HP = 0;
                else _HP = value;
            }
        }
        public Bitmap Bitmap
        {
            get { return _Bitmap; }
        }
        public Size TokenSize
        {
            get
            {
                return _TokenSize;
            }
        }
        public string? Name
        {
            get
            {
                return _Name;
            }
        }
        public Token Token
        {
            get
            {
                return _Token;
            }
        }
        public int Damage
        {
            get
            {
                return _Damage;
            }
        }
        public bool IsDead
        {
            get
            {
                return _IsDead;
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

        public BaseCharacter() //For Monsters and Items
        {
            _IsDead = false;
        }

        public BaseCharacter(Bitmap pic, string name) //For Player
        {
            _IsDead = false;
            _Bitmap = pic;
            _Name = name;
        }
        #endregion

        private static async void PlayerTimer_Tick(object? sender, EventArgs e)
        {
            List<Task> Tasks = new();
            foreach (BaseCharacter c in CharacterList)
            {
                var tmp = new Task(() => c.RotateToken());
                Tasks.Add(tmp);
                tmp.Start();
            }

            await Task.WhenAll(Tasks.ToArray());

            foreach (BaseCharacter c in CharacterList)
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
            if (Token.Left - Token.Width > Main.MainForm?.ClientSize.Width
                || Token.Left < 0)
                return false;
            if (Token.Top - Token.Height > Main.MainForm?.ClientSize.Height
                || Token.Top < 0)
                return false;
            return true;
        }
        private static void RemoveTheDead()
        {
            List<int> _IsDeadList = new();
            for (int i = 0; i < CharacterList.Count; i++)
                if (CharacterList[i]._IsDead) _IsDeadList.Add(i);

            for (int i = 0; i < _IsDeadList.Count; i++)
            {
                Main.MainForm.Controls.Remove(CharacterList[_IsDeadList[i] - i].Token);
                CharacterList[_IsDeadList[i] - i].Token.Dispose();
                CharacterList.RemoveAt(_IsDeadList[i] - i);
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
            if (!_IsDead) Token?.UpdateTokenHP(damage);
        }
        #endregion

        #region Movement
        private async Task RotateToken()
        {
            if (this is Player)
                await CalcTrajectory(Token.Left, Token.Top, _ThePlayer._ClickLocation.X, _ThePlayer._ClickLocation.Y);
            if (this is Monster && _ThePlayer is not null)
                await CalcTrajectory(Token.Left, Token.Top, _ThePlayer.Token.Left, _ThePlayer.Token.Top);

            Token.LocX += Token.StepX;
            Token.LocY += Token.StepY;
        }

        protected virtual void MoveToken()
        {
            Token.Left = (int)Token.LocX;
            Token.Top = (int)Token.LocY;

            if (!hasValidPosition())
                _IsDead = true;
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
                Token.StepX = _Speed * Math.Cos(radians);
                Token.StepY = _Speed * Math.Sin(radians);
            });
        }
        #endregion
    }
}