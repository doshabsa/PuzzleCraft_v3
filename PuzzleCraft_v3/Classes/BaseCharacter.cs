using System;
using System.Collections.Generic;
using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.Classes.Monsters;
using PuzzleCraft_v3.GUI;
using static PuzzleCraft_v3.Classes.Player;

namespace PuzzleCraft_v3.Classes
{
    public abstract class BaseCharacter
    {
        #region Properties
        protected Token _Token;
        protected string? _Name;
        protected bool _isSmart;
        protected bool _canMove;
        protected bool _isDead;
        protected double _Speed;
        protected int _HP;
        protected int _Damage;

        public static System.Windows.Forms.Timer? PlayerTimer = new();
        public static List<BaseCharacter> CharacterList = new();
        #endregion

        #region Public Properties
        public int Health
        {
            get { return _HP; }
            set
            {
                if (_HP <= 0) _isDead = true;
                else if (value < 0) _HP = 0;
                else _HP = value;
            }
        }

        public string? Name { get { return _Name; } }
        public Token Token { get { return _Token; } }
        public bool IsDead { get { return _isDead; } }
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
            _isDead = false;
            _Name = name;
        }

        public BaseCharacter(Bitmap pic, string name) //For Player
        {
            _isDead = false;
            _Name = name;
        }
        #endregion

        private static async void PlayerTimer_Tick(object? sender, EventArgs e)
        {
            List<Task> Tasks = new();
            foreach (BaseCharacter c in CharacterList)
            {
                if (c._isSmart)
                {
                    var tmp = new Task(() => c.RotateToken());
                    Tasks.Add(tmp);
                    tmp.Start();
                }
            }

            await Task.WhenAll(Tasks.ToArray());

            foreach (BaseCharacter c in CharacterList)
            {
                if (c._canMove)
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
            if (_Token.Left - _Token.Width > Main.MainForm?.ClientSize.Width
                || _Token.Left < 0)
                return false;
            if (_Token.Top - _Token.Height > Main.MainForm?.ClientSize.Height
                || _Token.Top < 0)
                return false;
            return true;
        }
        private static void RemoveTheDead()
        {
            List<int> isDeadList = new();
            for (int i = 0; i < CharacterList.Count; i++)
                if (CharacterList[i]._isDead)
                {
                    isDeadList.Add(i);
                    if (CharacterList[i] is Monster)
                        Monster.DeathDrop((Monster)CharacterList[i]);
                }

            for (int i = 0; i < isDeadList.Count; i++)
            {
                Main.MainForm.Controls.Remove(CharacterList[isDeadList[i] - i]._Token);
                CharacterList[isDeadList[i] - i]._Token.Dispose();
                CharacterList.RemoveAt(isDeadList[i] - i);
            }

            Backpack.RemoveUsedItems();
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
                                    CharacterList[i].OnCollision(
                                        CharacterList[j]._Damage, CharacterList[i]);
                                    CharacterList[j].OnCollision(
                                        CharacterList[i]._Damage, CharacterList[j]);
                                }
                if (Item.ItemList.Count > 0)
                    for (int i = 0; i < Item.ItemList.Count; i++)
                        if (CrashTest(Player._thePlayer, Item.ItemList[i]))
                        {
                            Player._thePlayer.OnCollision(
                                        Player._thePlayer._Damage, Item.ItemList[i]);
                        }
            }
            catch { }
        }

        private static bool CrashTest(BaseCharacter One, BaseCharacter Two)
        {
            if (One._Token.Left + One._Token.Width < Two._Token.Left) return false;
            if (Two._Token.Left + Two._Token.Width < One._Token.Left) return false;
            if (One._Token.Top + One._Token.Height < Two._Token.Top) return false;
            if (Two._Token.Top + Two._Token.Height < One._Token.Top) return false;
            return true;
        }

        private void OnCollision(int damage, BaseCharacter otherGuy)
        {
            if (this is Player && otherGuy is Item)
                Inventory.PickUp((Item)otherGuy);
            else
                Health -= damage;

            if (!_isDead) _Token?.UpdateTokenHP(this);
        }
        #endregion

        #region Movement
        protected virtual void Move()
        {
            _Token.LocX += _Token._StepX;
            _Token.LocY += _Token._StepY;
            _Token.Left = (int)_Token.LocX;
            _Token.Top = (int)_Token.LocY;

            if (!hasValidPosition())
                _isDead = true;
        }

        private async Task RotateToken()
        {
            if (this is Player)
                await CalcTrajectory(_Token.Left, _Token.Top, _thePlayer._ClickLocation.X, _thePlayer._ClickLocation.Y);
            if (this is Monster && _thePlayer is not null)
                await CalcTrajectory(_Token.Left, _Token.Top, _thePlayer._Token.Left, _thePlayer._Token.Top);
        }

        private async Task CalcTrajectory(int startX, int startY, int endX, int endY)
        {
            await Task.Run(() =>
            {
                double deltaX = endX - startX;
                double deltaY = endY - startY;
                double radians = Math.Atan2(deltaY, deltaX);
                double angle = radians * (180 / Math.PI);

                _Token.UpdatePictureDirection(this, (float)angle);
                _Token._StepX = _Speed * Math.Cos(radians);
                _Token._StepY = _Speed * Math.Sin(radians);
            });
        }
        #endregion
    }
}
