namespace PuzzleCraft_v3.Classes.Monsters
{
    internal class Wolf : _Monster
    {
        public Wolf() : base()
        {
            _ItemDrop0 = "feather";
            _ItemDrop1 = "bone";
            _ItemDrop2 = "wolf_trophy";
            _ItemDrop3 = null;
            _QuestItem = "wolf_trophy";

            _Name = "wolf";
            _CanMove = true;
            _IsSmart = true;
            _TokenSize = new(50, 50);
            _Bitmap = GetImage(_Name);
            _HP = 10;
            _Speed = 2;
            _Damage = 5;
            _Token = new(this);
            CharacterList.Add(this);
        }
    }
}
