﻿using PuzzleCraft_v3.GUI;
using System.Xml.Linq;

namespace PuzzleCraft_v3.Classes
{
    internal class Player : BaseCharacter
    {
        #region Properties/Fields
        public static Player _ThePlayer;
        public Point _ClickLocation;
        private bool _isMoving;
        #endregion

        #region Constructors
        public Player(Bitmap pic, string name) : base(pic, name)
        {
            _CanMove = true;
            _IsSmart = true;
            _ClickLocation = new();
            _TokenSize = new(100, 100);
            _ThePlayer = this;
            _Bitmap = pic;
            _Name = name;
            _HP = 100;
            _Speed = 3;
            _Damage = 5;
            _Token = new(this);
            _Pack = new();
            CharacterList.Add(this);
        }

        protected override void MoveToken()
        {
            _isMoving = true;
            while (_ClickLocation.X != Token.Left || Token.LocY != Token.Top)
            {
                if (Token.StepX > 0)
                {
                    Token.Left += (int)(Token.StepX < _ClickLocation.X - Token.Left ? Token.StepX : _ClickLocation.X - Token.Left);
                }
                else if (Token.StepX < 0)
                {
                    Token.Left += (int)(Token.StepX > _ClickLocation.X - Token.Left ? Token.StepX : _ClickLocation.X - Token.Left);
                }

                if (Token.StepY > 0)
                {
                    Token.Top += (int)(Token.StepY < _ClickLocation.Y - Token.Top ? Token.StepY : _ClickLocation.Y - Token.Top);
                }
                else if (Token.StepY < 0)
                {
                    Token.Top += (int)(Token.StepY > _ClickLocation.Y - Token.Top ? Token.StepY : _ClickLocation.Y - Token.Top);
                }

                if(Token.Left - _Token.StepX >= _ClickLocation.X || Token.LocY != Token.Top)
            }
            _isMoving = false;
        }
        #endregion
    }
}