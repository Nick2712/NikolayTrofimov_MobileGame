using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    [CreateAssetMenu(fileName = nameof(AbilityItemConfig), menuName = Constants.MOBILE_GAME + nameof(AbilityItemConfig))]
    internal sealed class AbilityItemConfig : ScriptableObject, IAbilityItem
    {
        [SerializeField] private ItemConfig _config;
        [field: SerializeField] public AbilityType Type { get; private set; }
        [field: SerializeField] public GameObject Projectile { get; private set; }
        [field: SerializeField] public float Value { get; private set; }

        public string Id => _config.Id;
        public Sprite Icon => _config.Icon;
    }
}
