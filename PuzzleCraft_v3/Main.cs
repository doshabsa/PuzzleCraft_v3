using PuzzleCraft_v3.Classes;

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

        private void button1_Click(object sender, EventArgs e)
        {
            BaseChar.TokenList[0].TestMethod();
        }
    }
}