using PuzzleCraft_v3.Classes.Items;
using PuzzleCraft_v3.GUI;

namespace PuzzleCraft_v3.Classes.Quests
{
    internal class Mission1 : _Quest
    {
        public Mission1() : base()
        {
            _Reward = NewRewards();
            _Title = "Collect Feathers";
            _Description = @"Birds provide an excellent source for feathers. Collect three of them to complete your quest.";
            QuestList.Add(this);
        }

        public override bool QuestStatus()
        {
            int tmp = 0;
            foreach(_Item item in Inventory.InventoryList)
            {
                if (item is Feather)
                    tmp++;
            }

            if (tmp >= 3)
            {
                _Item.ItemList.Remove(QuestLog._CurrentQuest.Reward);
                Inventory.InventoryList.Add(QuestLog._CurrentQuest.Reward);
                _IsComplete = true;
                return true;
            }
            else
                return false;
        }

        private static _Item NewRewards()
        {
            Gold g1 = new("gold");
            return g1;
        }
    }
}