using System;
using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal interface IAbilitiesView
    {
        void Display(IEnumerable<IAbilityItem> abilityItems, Action<string> clicked);
        void Clear();
    }
}
