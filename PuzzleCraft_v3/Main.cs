using PuzzleCraft_v3.Classes;
using static PuzzleCraft_v3.Classes.Player;

namespace PuzzleCraft_v3
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            BaseChar.MainForm = this;
            Start newGame = new();
            //Backpack newPack = new();
        }
    }
}