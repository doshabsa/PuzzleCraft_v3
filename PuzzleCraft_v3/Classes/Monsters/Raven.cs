﻿namespace PuzzleCraft_v3.Classes.Monsters
{
    internal class Raven : _Monster
    {
        public Raven() : base()
        {
            _ItemDrop0 = "arrow";
            _ItemDrop1 = null;
            _ItemDrop2 = null;
            _ItemDrop3 = null;
            _QuestItem = "gold";

            _CanMove = true;
            _IsSmart = true;
            _TokenSize = new(50, 50);
            _Bitmap = Resource1.raven;
            _Name = "Raven";
            _HP = 1;
            _Speed = 1;
            _Damage = 1;
            _Token = new(this);
            CharacterList.Add(this);
        }
    }
}
