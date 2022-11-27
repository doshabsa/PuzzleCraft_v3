using PuzzleCraft_v3.GUI;
using PuzzleCraft_v3.GUI.Token;

namespace PuzzleCraft_v3.Classes
{
    internal class Player : BaseCharacter
    {
        #region Properties/Fields
        public Point _ClickLocation;
        public static Player? _thePlayer;
        private bool _isMoving;
        private static Backpack? _Pack;
        #endregion

        #region Constructors
        public Player(Bitmap pic, string name)
        {
            _Name = name;
            _CanMove = true;
            _IsSmart = true;
            _CanRotate = true;
            _Speed = 2;
            _Damage = 3;
            _Image = pic;
            _Size = new(100, 100);
            _ClickLocation = new();
            _thePlayer = this;
            _HP = 100;
            _Pack = new();
            _Token = new(this);
            PlayerTimer.Start();
        }
        #endregion
        //there an issue here causeing player control to teleport/slide at random
        //while loop seems to help with it?
    }
}
