namespace PuzzleCraft_v3.Classes
{
    internal class Player : BaseCharacter
    {
        #region Properties/Fields
        public Point ClickLocation;
        public static Player? thePlayer;
        private bool isMoving;
        #endregion

        #region Constructors
        public Player(Bitmap pic, string name, Point loc, Size size) : base(pic, name)
        {
            canMove = true;
            isSmart = true;
            ClickLocation = new();
            thePlayer = this;
            CharName = name;
            HP = 100;
            Speed = 3;
            Damage = 5;
            Token = new(pic, size, loc, HP);
            CharacterList.Add(this);
        }
        #endregion

        protected override void Move()
        {
            isMoving = true;
            while (isMoving)
            {
                if (Token.StepX > 0)
                    Token.Left += (int)(Token.StepX < ClickLocation.X - Token.Left ? Token.StepX : ClickLocation.X - Token.Left);
                else if (Token.StepX < 0)
                    Token.Left += (int)(Token.StepX > ClickLocation.X - Token.Left ? Token.StepX : ClickLocation.X - Token.Left);

                if (Token.StepY > 0)
                    Token.Top += (int)(Token.StepY < ClickLocation.Y - Token.Top ? Token.StepY : ClickLocation.Y - Token.Top);
                else if (Token.StepY < 0)
                    Token.Top += (int)(Token.StepY > ClickLocation.Y - Token.Top ? Token.StepY : ClickLocation.Y - Token.Top);
                isMoving = false;
            }
        } 
        //there an issue here causeing player control to teleport/slide at random
        //while loop seems to help with it?
    }
}
