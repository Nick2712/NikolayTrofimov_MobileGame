using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    [CreateAssetMenu(fileName = nameof(UnityAdsSettings), menuName = Constants.MOBILE_GAME + nameof(UnityAdsSettings))]

    internal sealed class UnityAdsSettings : ScriptableObject
    {
        [field: Header("Game ID")]
        [field: SerializeField] public string GameId { get; private set; } = "4707919";

        [field: Header("Players")]
        [field: SerializeField] public AdsPlayerSettings Interstitial { get; private set; }
        [field: SerializeField] public AdsPlayerSettings Rewarded { get; private set; }
        [field: SerializeField] public AdsPlayerSettings Banner { get; private set; }

        [field: Header("Settings")]
        [field: SerializeField] public bool TestMode { get; private set; } = true;
        [field: SerializeField] public bool EnablePerPlacementMode { get; private set; } = true;
    }
}
