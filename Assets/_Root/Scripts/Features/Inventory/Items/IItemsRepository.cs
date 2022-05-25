using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal interface IItemsRepository : IRepository
    {
        IReadOnlyDictionary<string, IItem> Items { get; }
    }
}
