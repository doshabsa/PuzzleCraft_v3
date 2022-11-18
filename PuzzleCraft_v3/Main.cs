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
        }

        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            thePlayer.NewLocation = e.Location;
        }

        private void btn_Cheat_Click(object sender, EventArgs e)
        {
            
        }
    }
}