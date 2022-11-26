using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PuzzleCraft_v3.Classes.Monsters
{
    internal class Raven : Monster
    {
        public Raven(string name) : base(name)
        {
            _canMove = true;
            _isSmart = true;
            _HP = 1;
            _Speed = 2;
            _Damage = 1;
            _MonsterImage = Resource1.raven;
            _MonsterSize = new(35, 35);
            _Token = new(name, _MonsterImage, _MonsterSize, SpawnLocation(_MonsterSize), _HP, true);
        }
    }
}
