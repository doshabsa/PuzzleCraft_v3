using PuzzleCraft_v3.Classes;
using PuzzleCraft_v3.Classes.Items;
using static PuzzleCraft_v3.Classes.Player;

namespace PuzzleCraft_v3
{
    public delegate void Notify(Point e);

    public partial class Main : Form
    {
        public static Main? MainForm;
        public static event Notify GameLive;
        public static Point ClickLocation;
        public static bool PlayGame = false;

        public Main()
        {
            InitializeComponent();
            MainForm = this;
            Start newGame = new();
        }

        private void btn_Cheat_Click(object sender, EventArgs e)
        {
            Item drop = new("arrow");
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (_ThePlayer != null)
            {
                Player.PlayerTimer.Start();
                PlayGame = true;
                ClickLocation = e.Location;
            }
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            if (_ThePlayer != null)
            {
                Player.PlayerTimer.Stop();
                PlayGame = false;
                ClickLocation = new Point((int)Player._ThePlayer.Token.Left, (int)Player._ThePlayer.Token.Top);
            }
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (_ThePlayer != null && Main.PlayGame)
                ClickLocation = e.Location;
        }
    }
}