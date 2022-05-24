using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    [CreateAssetMenu(fileName = nameof(UpgradeItemConfigDataSource), menuName = Constants.MOBILE_GAME + nameof(UpgradeItemConfigDataSource))]
    internal sealed class UpgradeItemConfigDataSource : ScriptableObject
    {
        [SerializeField] private UpgradeItemConfig[] _upgradeItemConfigs;

        public IReadOnlyList<UpgradeItemConfig> ItemConfigs => _upgradeItemConfigs;
    }
}
