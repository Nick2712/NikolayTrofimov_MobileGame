using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    [CreateAssetMenu(fileName = nameof(AbilityItemConfigDataSource), menuName = Constants.MOBILE_GAME + nameof(AbilityItemConfigDataSource))]
    internal sealed class AbilityItemConfigDataSource : ScriptableObject
    {
        [SerializeField] private AbilityItemConfig[] _abilityItemConfigs;

        public IReadOnlyList<AbilityItemConfig> AbilityConfigs => _abilityItemConfigs;
    }
}
