using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    [CreateAssetMenu(fileName = nameof(UpgradeItemConfig), menuName = Constants.MOBILE_GAME + nameof(UpgradeItemConfig))]
    internal class UpgradeItemConfig : ScriptableObject
    {
        [SerializeField] private ItemConfig _itemConfig;
        [field: SerializeField] public UpgradeType Type { get; private set; }
        [field: SerializeField] public float Value { get; private set; }

        public string Id => _itemConfig.Id;
    }
}
