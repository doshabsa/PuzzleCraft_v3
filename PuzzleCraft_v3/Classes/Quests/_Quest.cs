using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.Classes.Monsters;

namespace PuzzleCraft_v3.Classes.Quests
{
    internal class _Quest
    {
        public int _ID;
        private string _Title;
        private string _Description;
        private Bitmap _Photo;
        private List<_Item> _RewardList; //One list, it just refills/refreshse per quest
        private static Random rnd = new Random();

        private static List<_Quest> QuestList;

        public string Title { get { return _Title; } }
        public string Description { get { return _Description; } }
        public Bitmap Photo { get { return _Photo; } }  
        public List<_Item> RewardList { get { return _RewardList; } }

        static _Quest()
        {
            QuestList = new();
        }

        public _Quest(string title, string description, Bitmap pic)
        {
            //perhaps eventually have quests pick a monster as the "kill" target, then
            //pull that targeted monsters inventory as reward
            _RewardList = new List<_Item>();
            NewRewards();

            _Title = title;
            _Description = description;
            _Photo = pic;
            QuestList.Add(this);
        }

        private static List<_Item> NewRewards()
        {
            //Adjust a stopwatch/timer to trigger quest creations?
            //A list, to accomodate additional rewards per quest
            List<_Item> list = new();

            _Character character = _Character.CharacterList[rnd.Next(1, _Character.CharacterList.Count)];
            string tmp = _Monster.GetQuestItem((_Monster)character);
            list.Add(_Item.CreateTreasure(tmp));
            return list;
        }
    }
}
