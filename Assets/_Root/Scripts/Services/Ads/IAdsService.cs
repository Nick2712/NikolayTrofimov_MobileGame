using UnityEngine.Events;


namespace NikolayTrofimov_MobileGame
{
    internal interface IAdsService
    {
        IAdsPlayer InterstitialPlayer { get; }
        IAdsPlayer RewardedPlayer { get; }
        IAdsPlayer BannerPlayer { get; }
        UnityEvent Initializer { get; }
        bool IsInitialized { get; }
    }
}
