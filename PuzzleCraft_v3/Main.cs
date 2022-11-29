using PuzzleCraft_v3.Classes;
using static PuzzleCraft_v3.Classes.Player;

namespace PuzzleCraft_v3
{
    public partial class Main : Form
    {
        public static Main? MainForm;

        public Main()
        {
            InitializeComponent();
            MainForm  = this;
            Start newGame = new();
        }

        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (_ThePlayer is null) { /* do nothing, there is no player */ }
            else
                _ThePlayer._ClickLocation = e.Location;
        }

        private void btn_Cheat_Click(object sender, EventArgs e)
        {

        }
    }
}