using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.Classes.Monsters;

namespace PuzzleCraft_v3.Classes.Quests
{
    public class _Quest
    {

        /*
         I ran out of time to implement a more robust quest/reward system - so just made due.
         */
        public delegate void UpdateQuest(_Quest quest);
        public UpdateQuest Alert;

        protected string _Title;
        protected string _Description;
        protected bool _IsComplete;
        protected _Item _Reward; //optionally use a list?
        protected static Random rnd = new Random();

        public static List<_Quest> QuestList;

        public string Title { get { return _Title; } }
        public string Description { get { return _Description; } } 
        public _Item Reward { get { return _Reward; } }
        public bool IsComplete { get; set; } //Eventually make this less accessible

        static _Quest()
        {
            QuestList = new();
        }

        public _Quest()
        {
            _IsComplete = false;
            QuestList.Add(this);
        }

        public virtual bool QuestStatus()
        {
            return false;
        }

        protected virtual _Item NewRewards()
        {
            return null;
        }
    }
}
