using PuzzleCraft_v3.GUI.Token;
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
        public Raven()
        {
            _Name = "raven";
            _CanMove = true;
            _IsSmart = true;
            _CanRotate = true;
            _IsDead = false;
            _HP = 1;
            _Speed = 2;
            _Damage = 1;
            _Image = Resource1.raven;
            _Size = new(35, 35);
            _Token = new(this);
        }
    }
}
