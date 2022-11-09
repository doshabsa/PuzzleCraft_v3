using PuzzleCraft_v3.Classes;

namespace PuzzleCraft_v3
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            BaseChar.mainForm = this;
            Start newGame = new();
        }
    }
}