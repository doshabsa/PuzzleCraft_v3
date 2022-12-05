using PuzzleCraft_v3.Classes.Items;

namespace PuzzleCraft_v3.Classes.Quests
{
    internal class Mission1 : _Quest
    {
        public Mission1() : base()
        {
            _ID++;
            //perhaps eventually have quests pick a monster as the "kill" target, then
            //pull that targeted monsters inventory as reward (make it work, for now)
            _RewardList = new List<_Item>();
            _RewardList.Add(NewRewards());

            _Title = "Slaughter Birds";
            _Description = @"Birds provide an excellent source for feathers, which can be used to craft
                            arrows. Arrows can be used to protect yourself. You will need to create a bow though!";
            _Photo = Resource1.cat;
            QuestList.Add(this);
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