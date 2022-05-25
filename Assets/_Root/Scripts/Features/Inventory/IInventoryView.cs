using System;
using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal interface IInventoryView
    {
        void Display(IEnumerable<IItem> itemsCollection, Action<string> itemClicked);
        void Clear();
        void Select(string id);
        void Unselect(string id);
    }
}
