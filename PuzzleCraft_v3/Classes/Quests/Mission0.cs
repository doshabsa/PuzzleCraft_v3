using PuzzleCraft_v3.Classes.Items;

namespace PuzzleCraft_v3.Classes.Quests
{
    internal class Mission0 :_Quest
    {
        public Mission0() : base()
        {
            _ID++;
            //perhaps eventually have quests pick a monster as the "kill" target, then
            //pull that targeted monsters inventory as reward (make it work, for now)
            _RewardList = new List<_Item>();
            _RewardList.Add(NewRewards());

            _Title = "Tutorial";
            _Description = @"Welcome to Puzzlecraft! This game was created for the ITEC 225 (Programming) class of 2022!
                            This version includes a simplification of code, while making it more adaptable to ongoing changes
                            to the base idea of the game. 
                            In this redition, key press controls have been removed and replaced with movement to the mouse loation
                            on click press/hold. As well, there is now diagonal movement and a more easily configured monster/item
                            collection.
                            To begin, please click anywhere on the main form to dismiss this message.";
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