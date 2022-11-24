namespace PuzzleCraft_v3.Classes
{
    internal class Player : BaseCharacter
    {
        #region Properties/Fields
        public static Player thePlayer;
        private Point MoveLocation;
        private bool isMoving;
        #endregion

        #region Constructors
        public Player(Bitmap pic, string name, Point loc, Size size) : base(pic, name)
        {
            MoveLocation = new();
            thePlayer = this;
            CharName = name;
            HP = 100;
            Speed = 2;
            Damage = 5;
            Token = new(pic, size, loc, HP);
            CharacterList.Add(this);
        }
        #endregion

        protected override void Move()
        {
            MoveLocation = ClickLocation;
            if(!isMoving)
                MoveToClick();
        }

        private async void MoveToClick()
        {
            isMoving = true;
            while (MoveLocation.X != Token.Left || MoveLocation.Y != Token.Top)
            {
                await Task.Delay(5);

                if (Token.StepX > 0)
                {
                    Token.Left += (int)(Token.StepX < MoveLocation.X - Token.Left ? Token.StepX : MoveLocation.X - Token.Left);
                }
                else if (Token.StepX < 0)
                {
                    Token.Left += (int)(Token.StepX > MoveLocation.X - Token.Left ? Token.StepX : MoveLocation.X - Token.Left);
                }

                if (Token.StepY > 0)
                {
                    Token.Top += (int)(Token.StepY < MoveLocation.Y - Token.Top ? Token.StepY : MoveLocation.Y - Token.Top);
                }
                else if (Token.StepY < 0)
                {
                    Token.Top += (int)(Token.StepY > MoveLocation.Y - Token.Top ? Token.StepY : MoveLocation.Y - Token.Top);
                }
            }
            isMoving = false;
        }
    }
}
