using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    [CreateAssetMenu(fileName = nameof(ItemConfig), menuName = Constants.MOBILE_GAME + nameof(ItemConfig))]
    internal class ItemConfig : ScriptableObject, IItem
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; } 
    }
}
