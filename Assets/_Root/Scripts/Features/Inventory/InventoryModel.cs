using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal class InventoryModel : IInventoryModel
    {
        private readonly List<string> _equipedItems = new();
        public IReadOnlyList<string> EquipedItems => _equipedItems;


        public void EquipItem(string itemId)
        {
            if(!_equipedItems.Contains(itemId)) _equipedItems.Add(itemId);
        }

        public void UnequipItem(string itemId)
        {
            if (_equipedItems.Contains(itemId)) _equipedItems.Remove(itemId);
        }

        public bool IsEquipped(string itemId)
        {
            return _equipedItems.Contains(itemId);
        }
    }
}
