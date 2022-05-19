using System;
using UnityEngine;
using UnityEngine.Advertisements;


namespace NikolayTrofimov_MobileGame
{
    internal abstract class UnityAdsPlayerBase : IAdsPlayer, IUnityAdsListener
    {
        public event Action Started;
        public event Action Finished;
        public event Action Failed;
        public event Action Skipped;
        public event Action BecomeReady;

        protected readonly string _id;

        public UnityAdsPlayerBase(string id)
        {
            _id = id;
            Advertisement.AddListener(this);
        }

        public void Play()
        {
            Load();
            OnPlaying();
            Load();
        }

        protected abstract void OnPlaying();
        protected abstract void Load();

        void IUnityAdsListener.OnUnityAdsDidError(string message)
        {
            Debug.Log($"Error: {message}");
        }

        void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (!IsIdMy(placementId)) return;

            switch (showResult)
            {
                case ShowResult.Finished:
                    Debug.Log("Finished");
                    Finished?.Invoke();
                    break;
                case ShowResult.Failed:
                    Debug.Log("Failed");
                    Failed?.Invoke();
                    break;
                case ShowResult.Skipped:
                    Debug.Log("Skipped");
                    Skipped?.Invoke();
                    break;
            }
        }

        void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
        {
            if(!IsIdMy(placementId)) return;

            Debug.Log("Started");
            Started?.Invoke();
        }

        void IUnityAdsListener.OnUnityAdsReady(string placementId)
        {
            if (!IsIdMy(placementId)) return;

            Debug.Log("Ready");
            BecomeReady?.Invoke();
        }

        private bool IsIdMy(string id) => _id == id;
    }
}
