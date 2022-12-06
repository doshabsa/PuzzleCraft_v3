using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.GUI;

namespace PuzzleCraft_v3.Classes.Quests
{
    internal class Mission0 :_Quest
    {
        public Mission0() : base()
        {
            _Reward = NewRewards();
            _Title = "Tutorial";
            _Description = @"Welcome to Puzzlecraft! This game was created for the ITEC 225 (Programming) class of 2022!
This version includes a simplification of code, while making it more adaptable to ongoing changes
to the base idea of the game. In this redition, key press controls have been removed and replaced with movement to the mouse loation
on click press/hold. As well, there is now diagonal movement and a more easily configured monster/item collection.

To hand in your quests, click the reward shown below. (To begin yoru quests, please click the wolf head.)

!!!! DAMAGE IS CURRENTLY DISABLED IN DEMO MODE (but it does work) !!!";
            QuestList.Add(this);
        }

        public override bool QuestStatus()
        {
            if (!Inventory.InventoryList.Contains(_Reward))
            {
                _Item.ItemList.Remove(QuestLog._CurrentQuest.Reward);
                Inventory.InventoryList.Add(QuestLog._CurrentQuest.Reward);
                _IsComplete = true;
                return true;
            }
            else
                return false;
        }

        protected override _Item NewRewards()
        {
            Wolf_Trophy item = new("wolf_trophy");
            return item;
        }
    }
}