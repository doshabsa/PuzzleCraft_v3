using PuzzleCraft_v3.Classes;
using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.Classes.Quests;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace PuzzleCraft_v3.GUI
{
    public partial class QuestLog : UserControl
    {
        private static Queue<_Quest> QuestQueue;
        public static _Quest _CurrentQuest;
        public static Button btnLog;
        private bool IsVisible = false;

        public _Quest CurrentQuest 
        { 
            get { return _CurrentQuest; } 
            set 
            { 
                _CurrentQuest = value; 
            } 
        }

        static QuestLog()
        {
            QuestQueue = new();
        }

        public QuestLog()
        {
            InitializeComponent();
            this.Dock = DockStyle.Right;
            SetupPackButton();
            QueueMissions();
            QuestStart(QuestQueue.First());
            this.Visible = false;
            Main.MainForm?.Controls.Add(this);
        }

        #region Manage Quests
        private void QuestStart(_Quest quest)
        {
            _CurrentQuest = quest;
            lblTitle.Text = quest.Title;
            rtbDescription.Text = quest.Description;
            picReward.Image = quest.Reward.Bitmap;
        }

        private void QuestComplete(_Quest quest)
        {
            picReward.Image = null;
            QuestQueue.Dequeue();
            if (QuestQueue.Count > 0)
            {
                QuestStart(QuestQueue.First());
            }
            else
                CleanLog();
        }

        private void CleanLog()
        {
            _CurrentQuest = null;
            lblTitle.Text = null;
            rtbDescription.Text = "You are done all the current quests :)";
            picReward.Image = null;
        }
        #endregion

        #region Setup QuestLog
        private void SetupPackButton()
        {
            btnLog = new();
            btnLog.FlatStyle = FlatStyle.Flat;
            btnLog.Size = new Size(109, 33);
            btnLog.Location = new Point(Main.MainForm.ClientSize.Width - btnLog.Width - 6, 6);
            btnLog.Text = "Quest Log";
            btnLog.Font = new Font("Arial", 9, FontStyle.Bold);
            btnLog.ForeColor = Color.DarkGoldenrod;
            btnLog.Click += BtnPack_Click;
            Main.MainForm.Controls.Add(btnLog);
        }

        private void BtnPack_Click(object? sender, EventArgs e)
        {
            if (!IsVisible)
            {
                IsVisible = true;
                this.Show();
                this.BringToFront();
            }
            else
            {
                IsVisible = false;
                this.Hide();
            }
        }
        #endregion

        #region Events
        private void picReward_Click(object sender, EventArgs e)
        {
            if (_CurrentQuest.QuestStatus())
            {
                QuestComplete(_CurrentQuest);
            }
        }

        private void QueueMissions()
        {
            Mission0 q0 = new();
            QuestQueue.Enqueue(q0);

            Mission1 q1 = new();
            QuestQueue.Enqueue(q1);

            //Mission1 q2 = new();
            //QuestQueue.Enqueue(q2);
        }
        #endregion

    }
}
