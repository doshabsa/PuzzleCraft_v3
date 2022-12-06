namespace PuzzleCraft_v3.Classes.Monsters
{
    internal class Rabbit : _Monster
    {
        public Rabbit() : base()
        {
            _ItemDrop0 = "rabbitfoot";
            _ItemDrop1 = "rabbitfoot";
            _ItemDrop2 = null;
            _ItemDrop3 = null;
            _QuestItem = "gold";

            _CanMove = false;
            _IsSmart = true;
            _TokenSize = new(50, 50);
            _Bitmap = Resource1.rabbit;
            _Name = "Rabbit";
            _HP = 5;
            _Speed = 0;
            _Damage = 1;
            _Token = new(this);
            CharacterList.Add(this);
        }
    }
}
