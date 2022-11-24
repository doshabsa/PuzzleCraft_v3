namespace PuzzleCraft_v3.Classes
{
    internal class Player : BaseCharacter
    {
        #region Properties/Fields
        public static Player thePlayer;
        #endregion

        #region Constructors
        public Player(Bitmap pic, string name, Point loc, Size size) : base(pic, name)
        {
            thePlayer = this;
            CharName = name;
            HP = 100;
            Speed = 2;
            Damage = 5;
            Token = new(pic, size, loc, HP);
            CharacterList.Add(this);
        }
        #endregion
    }
}
