namespace PuzzleCraft_v3.Classes
{
    internal class Player : BaseChar
    {
        #region Properties/Fields
        public static Player thePlayer;
        #endregion

        #region Constructors
        public Player(Bitmap pic, string name, Point loc, Size size) : base(pic, name)
        {
            thePlayer = this;
            HP = 100;
            Speed = 2;
            Damage = 5;
            Token = new(pic, size, loc, HP);
            CharacterList.Add(this);
        }
        #endregion
    }
}
