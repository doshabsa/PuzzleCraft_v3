namespace PuzzleCraft_v3.Classes.Monsters
{
    internal class Skeleton : _Monster
    {
        public Skeleton() : base()
        {
            _ItemDrop0 = "bone";
            _ItemDrop1 = "bone";
            _ItemDrop2 = "bone";
            _ItemDrop3 = "bone";

            _CanMove = false;
            _IsSmart = false;
            _TokenSize = new(50, 50);
            _Bitmap = Resource1.skeleton;
            _Name = "Skeleton";
            _HP = 1;
            _Speed = 0;
            _Damage = 0;
            _Token = new(this);
            CharacterList.Add(this);
        }
    }
}
