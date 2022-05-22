using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal interface IInventoryModel
    {
        IReadOnlyList<string> EquipedItems { get; }
        void EquipItem(string itemId);
        void UnequipItem(string itemId);
        bool IsEquipped(string itemId);
    }
}
