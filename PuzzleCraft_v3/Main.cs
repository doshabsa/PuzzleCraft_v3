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
        public static bool PlayGame = false;

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
                _ClickLocation = e.Location;
        }

        private void btn_Cheat_Click(object sender, EventArgs e)
        {
            Item drop = new("arrow");
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            _ThePlayer._isMoving = true;
            _ClickLocation = e.Location;
        }

        private void OnGameLive(Point e)
        {
            //GameLive?.Invoke(e);
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            _ThePlayer._isMoving = false;
            Player._ClickLocation = new Point((int)Player._ThePlayer.Token.LocX, (int)Player._ThePlayer.Token.LocY);
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (_ThePlayer != null && _ThePlayer._isMoving)
                _ClickLocation = e.Location;
        }
    }
}