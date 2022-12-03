using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.GUI;
using System;
using System.Collections.Generic;
using static PuzzleCraft_v3.Classes.Player;

namespace PuzzleCraft_v3.Classes
{
    public abstract class BaseCharacter
    {
        #region Fields
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
        public bool Moving;

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
                if (_HP <= 0)
                {
                    _IsDead = true;
                }
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
        public bool CanMove
        {
            get
            {
                return _CanMove;
            }
        }
        public bool IsSmart
        {
            get
            {
                return _IsSmart;
            }
        }
        public bool IsDead
        {
            get { return _IsDead; }
            set
            {
                if (this is Item)
                    _IsDead = value;
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

        protected Bitmap? GetImage(string? name)
        {
            object? DesiredItem = Resource1.ResourceManager.GetObject(name);
            Bitmap? pic = (Bitmap)DesiredItem;
            return pic;
        }
        #endregion

        private static void PlayerTimer_Tick(object? sender, EventArgs e)
        {
            foreach (BaseCharacter c in CharacterList)
                if(c._IsSmart)
                    c.RotateToken();

            foreach (BaseCharacter c in CharacterList)
                if(c._CanMove)
                    c.MoveToken();

            CheckForCrash();
            Backpack.UpdateItems();
            RemoveTheDead();


            if (CharacterList.Count < 2)
            {
                Monster.CreateNewMonster();
                GC.Collect(); //Optional; it never actually overflows
            }
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
                if (CharacterList[i]._IsDead)
                {
                    if(CharacterList[i] != _ThePlayer)
                        _IsDeadList.Add(i);

                    if (CharacterList[i] is Player)
                    {
                        Player.GameOver();
                    }
                    else if (CharacterList[i] is Monster)
                    {
                        (Point, string?) tmp = Monster.DeathDrop((Monster)CharacterList[i]);
                        Item.CreateNewItem(tmp.Item1, tmp.Item2);
                    }
                }

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
                                    CharacterList[i].OnCollision(
                                        CharacterList[j]._Damage, CharacterList[i]);
                                    CharacterList[j].OnCollision(
                                        CharacterList[i]._Damage, CharacterList[j]);
                                }
                if (Item.ItemList.Count > 0)
                    for (int i = 0; i < Item.ItemList.Count; i++)
                        if (CrashTest(Player._ThePlayer, Item.ItemList[i]))
                            Player._ThePlayer.OnCollision(Player._ThePlayer._Damage, Item.ItemList[i]);
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

        private void OnCollision(int damage, BaseCharacter otherGuy)
        {
            if (this is Player && otherGuy is Item)
                Inventory.PickUp((Item)otherGuy);
            else
                Health -= damage;

            _Token?.UpdateTokenHP(this);
        }
        #endregion

        #region Movement
        private void RotateToken()
        {
            if (this is Player)
                CalcTrajectory(Token.Left, Token.Top, Main.ClickLocation.X, Main.ClickLocation.Y);
            if (this is Monster && _ThePlayer is not null)
                CalcTrajectory(Token.Left, Token.Top, _ThePlayer.Token.Left, _ThePlayer.Token.Top);
        }

        protected virtual void MoveToken()
        {
            Token.LocX += Token.StepX;
            Token.LocY += Token.StepY;
            Token.Left = (int)Token.LocX;
            Token.Top = (int)Token.LocY;

            if (!hasValidPosition())
                _IsDead = true;
        }

        private void CalcTrajectory(int startX, int startY, int endX, int endY)
        {
            double deltaX = endX - startX;
            double deltaY = endY - startY;
            double radians = Math.Atan2(deltaY, deltaX);
            double angle = radians * (180 / Math.PI);

            Token.UpdatePictureDirection((float)angle);
            Token.StepX = _Speed * Math.Cos(radians);
            Token.StepY = _Speed * Math.Sin(radians);
        }
        #endregion
    }
}