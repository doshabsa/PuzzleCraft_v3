using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v3.Classes.Quests
{
    public class QuestHelper
    {
        private Queue<_Quest> QuestQueue;
        private int QuestTracker = 0;

        public QuestHelper()
        {
            QuestQueue = new();
        }

        private void SetupQuest()
        {
            switch(QuestTracker)
            {
                case 0:
                    QuestQueue.Enqueue(new Mission0());
                    break;
                case 1:
                    QuestQueue.Enqueue(new Mission1());
                    break;
            }
        }
    }
}
