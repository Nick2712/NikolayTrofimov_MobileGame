using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal interface IAbilitiesRepository : IRepository
    {
        IReadOnlyDictionary<string, IAbility> Items { get; }
    }
}
