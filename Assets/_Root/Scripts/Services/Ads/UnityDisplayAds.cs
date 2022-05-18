using UnityEngine;
using UnityEngine.Advertisements;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class UnityDisplayAds : IDisplayAds, IUnityAdsInitializationListener
    {
        private const string GAME_ID_ANDROID = "4707919";
        private const string REWARDED_ANDROID = "Rewarded_Android";
        private const float MAX_TIME_TO_READY = 3.0f;

        private static UnityDisplayAds _unityDisplayAds;
        public static UnityDisplayAds Instance
        { 
            get 
            { 
                if (_unityDisplayAds == null) _unityDisplayAds = new UnityDisplayAds();
                return _unityDisplayAds; 
            } 
        }

        private float _timeToReady;


        private UnityDisplayAds()
        {
            Advertisement.Initialize(GAME_ID_ANDROID, true, true, this);
        }

        public void ShowRewarded()
        {
            if (Advertisement.IsReady(REWARDED_ANDROID))
            {
                Advertisement.Show(REWARDED_ANDROID);
            }
            else
            {
                Advertisement.Load(REWARDED_ANDROID);
                UpdateManager.UpdateAction += CheckReady;
                _timeToReady = MAX_TIME_TO_READY;
            }
        }

        public void OnInitializationComplete()
        {
            Debug.Log("Реклама инициализирована");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Реклама с ошибкой инициализации: error - {error} : message - {message}");
        }

        private void CheckReady(float deltaTime)
        {
            if (Advertisement.IsReady(REWARDED_ANDROID))
            {
                UpdateManager.UpdateAction -= CheckReady;
                ShowRewarded();
            }
            else
            {
                _timeToReady -= deltaTime;
                if(_timeToReady < 0)
                {
                    UpdateManager.UpdateAction -= CheckReady;
                    Debug.Log($"реклама не смогла загрузиться за время {MAX_TIME_TO_READY} сек");
                }
            }
        }
    }
}
