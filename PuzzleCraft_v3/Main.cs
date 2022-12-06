using PuzzleCraft_v3.Classes;
using static PuzzleCraft_v3.Classes.Player;

namespace PuzzleCraft_v3
{
    public partial class Main : Form
    {
        public static Main? MainForm;
        public static Point ClickLocation;
        public static bool PlayGame = false;

        public Main()
        {
            InitializeComponent();
            MainForm = this;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            Start newGame = new();
            newGame.EndGame += GameOver;
        }

        private void GameOver()
        {
            MessageBox.Show("You have died - please play again.");
            Start newGame = new();
            newGame.EndGame += GameOver;
        }

        #region Mouse Events
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (_ThePlayer != null && !_ThePlayer.IsDead)
            {
                Player.PlayerTimer.Start();
                PlayGame = true;
                ClickLocation = e.Location;
            }
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (_ThePlayer != null && Main.PlayGame && !_ThePlayer.IsDead)
                ClickLocation = e.Location;
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
        #endregion
    }
}