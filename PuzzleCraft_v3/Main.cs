using PuzzleCraft_v3.Classes;
using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.Classes.Monsters;
using PuzzleCraft_v3.GUI;
using static PuzzleCraft_v3.Classes.Player;

namespace PuzzleCraft_v3
{
    public delegate void Notify(Point e);

    public partial class Main : Form
    {
        public static Main? MainForm;
        public static Point ClickLocation;
        public static bool PlayGame = false;

        public Main()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            MainForm = this;
            Start newGame = new();
            newGame.ShowPack += PackButtonVisible;
        }
        private void PackButtonVisible()
        {
            btnBackpack.Visible = true;
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (_ThePlayer != null && !_ThePlayer.IsDead)
            {
                Player.PlayerTimer.Start();
                PlayGame = true;
                ClickLocation = e.Location;
            }
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            if (_ThePlayer != null && !_ThePlayer.IsDead)
            {
                Player.PlayerTimer.Stop();
                PlayGame = false;
                ClickLocation = new Point((int)Player._ThePlayer.Token.Left, (int)Player._ThePlayer.Token.Top);
            }
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (_ThePlayer != null && Main.PlayGame && !_ThePlayer.IsDead)
                ClickLocation = e.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player._ThePlayer.Pack.ToggleBag();
            if (btnBackpack.Text == "Open Pack")
            {
                btnBackpack.Text = "Close Pack";
                btnBackpack.BringToFront();
            }
            else
                btnBackpack.Text = "Open Pack";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _ThePlayer.Health -= 10;
            _ThePlayer.Token.UpdateTokenHP(_ThePlayer);
        }
    }
}