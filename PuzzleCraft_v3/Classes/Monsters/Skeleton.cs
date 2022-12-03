namespace PuzzleCraft_v3.Classes.Monsters
{
    internal class Skeleton : _Monster
    {
        public Skeleton() : base()
        {
            _ItemDrop0 = "arrow";
            _ItemDrop1 = null;
            _ItemDrop2 = null;
            _ItemDrop3 = null;

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
