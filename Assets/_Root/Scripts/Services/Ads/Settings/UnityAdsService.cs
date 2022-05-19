using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class UnityAdsService : MonoBehaviour, IAdsService, IUnityAdsInitializationListener
    {
        [Header("Components")]
        [SerializeField] private UnityAdsSettings _settings;

        [field: Header("Events")]
        [field: SerializeField] public UnityEvent Initialized { get; private set; }

        public IAdsPlayer InterstitialPlayer { get; private set; }

        public IAdsPlayer RewardedPlayer { get; private set; }

        public IAdsPlayer BannerPlayer { get; private set; }

        public UnityEvent Initializer => throw new System.NotImplementedException();

        public bool IsInitialized => throw new System.NotImplementedException();

        private void Awake()
        {
            InitializeAds();
            InitializePlayers();
        }

        private void InitializeAds() => Advertisement.Initialize(_settings.GameId);

        private void InitializePlayers()
        {
            InterstitialPlayer = CreateInterstitial();
            RewardedPlayer = CreateRewarded();
            BannerPlayer = CreateBanner();
        }

        private IAdsPlayer CreateInterstitial() => new EmptyPlayer("");

        private IAdsPlayer CreateRewarded() => new EmptyPlayer("");

        private IAdsPlayer CreateBanner() => new EmptyPlayer("");

        void IUnityAdsInitializationListener.OnInitializationComplete()
        {
            Debug.Log("Initialization Complete");
            Initialized?.Invoke();
        }

        void IUnityAdsInitializationListener.OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Initialization failed {error.ToString()} - {message}");
        }
    }
}
