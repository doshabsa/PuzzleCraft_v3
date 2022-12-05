using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.Classes.Monsters;

namespace PuzzleCraft_v3.Classes.Quests
{
    internal class _Quest
    {
        public static int _ID;
        protected string _Title;
        protected string _Description;
        protected Bitmap _Photo;
        protected List<_Item> _RewardList; //One list, it just refills/refreshes per quest
        protected static Random rnd = new Random();

        protected static List<_Quest> QuestList;

        public string Title { get { return _Title; } }
        public string Description { get { return _Description; } }
        public Bitmap Photo { get { return _Photo; } }  
        public List<_Item> RewardList { get { return _RewardList; } }

        static _Quest()
        {
            QuestList = new();
        }

        public _Quest()
        {

        }

        private static _Item NewRewards()
        {
            //Adjust a stopwatch/timer to trigger quest creations?
            //An item list, to accomodate additional rewards per quest (for now it is a single item)
            List<_Item> list = new();

            _Character character = _Character.CharacterList[rnd.Next(1, _Character.CharacterList.Count)];
            _Item newReward = _Item.CreateTreasure(_Monster.GetQuestItem((_Monster)character));

            //Currently the only active reward is gold, which is handled differently than other items
            return newReward;
        }
    }
}
