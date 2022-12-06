namespace PuzzleCraft_v3.Classes.Items
{
    public class RabbitFoot : _Item
    {

        public RabbitFoot(string name) : base(name)
        {
            if (name != null)
            {
                _Name = name;
                _TokenSize = new Size(40, 40);
                _HP = 1;
                _Damage = 0;
                _CanMove = false;
                _IsSmart = false;
                _Bitmap = GetImage(name);
                _Token = new(this);
                _Item.ItemList.Add(this);
            }
        }

        public override void UseItem()
        {
            MessageBox.Show("Honestly, this doesn't feel very lucky.");
            Gold.Count += 3;
        }
    }
}
