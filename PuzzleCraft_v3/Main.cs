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

        public Main()
        {
            InitializeComponent();
            MainForm = this;
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
            Item drop = new("arrow");
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            while (true)
            {
                OnGameLive(e.Location);
            }
        }

        private void OnGameLive(Point e)
        {
            GameLive?.Invoke(e);
        }
    }
}