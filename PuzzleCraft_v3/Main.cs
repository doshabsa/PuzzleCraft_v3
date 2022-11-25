using PuzzleCraft_v3.Classes;
using static PuzzleCraft_v3.Classes.Player;

namespace PuzzleCraft_v3
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            BaseCharacter.MainForm = this;
            Start newGame = new();
        }

        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (thePlayer is null) { /* do nothing, there is no player */ }
            else
                thePlayer.ClickLocation = e.Location;
        }

        private void btn_Cheat_Click(object sender, EventArgs e)
        {

        }
    }
}