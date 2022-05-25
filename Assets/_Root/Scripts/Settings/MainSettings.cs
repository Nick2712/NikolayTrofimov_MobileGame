using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    [CreateAssetMenu(fileName = nameof(MainSettings), menuName = Constants.MOBILE_GAME + nameof(MainSettings))]
    internal sealed class MainSettings : ScriptableObject
    {
        [field: SerializeField] public GameSettings GameSettings { get; private set; }
        [field: SerializeField] public UnityAdsSettings AdsSettings { get; private set; }
        [field: SerializeField] public ProductLibrary ProductLibrary { get; private set; }
    }
}
