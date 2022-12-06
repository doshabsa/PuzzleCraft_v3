namespace PuzzleCraft_v3.Classes.Monsters
{
    internal class Raven : _Monster
    {
        public Raven() : base()
        {
            _ItemDrop0 = "feather";
            _ItemDrop1 = "feather";
            _ItemDrop2 = "feather";
            _ItemDrop3 = "feather";
            _QuestItem = "gold";

            _CanMove = true;
            _IsSmart = true;
            _TokenSize = new(50, 50);
            _Bitmap = Resource1.raven;
            _Name = "Raven";
            _HP = 1;
            _Speed = 1;
            _Damage = 0;
            _Token = new(this);
            CharacterList.Add(this);
        }
    }
}
