using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    [CreateAssetMenu(fileName = nameof(ItemConfigDataSource), menuName = Constants.MOBILE_GAME + nameof(ItemConfigDataSource))]
    internal class ItemConfigDataSource : ScriptableObject
    {
        [SerializeField] private ItemConfig[] _itemConfigs;
        public IReadOnlyList<ItemConfig> ItemConfigs => _itemConfigs;
    }
}
