using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class Main : MonoBehaviour
    {
        private const string MAIN_SETTINGS_PATH = "MainSettings";

        [SerializeField] private Transform _placeForUI;

        private MainController _controller;


        private void Awake()
        {
            var mainSettings = ResourceLoader.LoadResource<MainSettings>(MAIN_SETTINGS_PATH);
            var gameSettings = mainSettings.GameSettings;
            _controller = new MainController(_placeForUI, gameSettings.Speed, gameSettings.JumpHeight, gameSettings.Transport);
            UnityAdsService.Instance.Init(mainSettings.AdsSettings);
            IAPService.Instance.Init(mainSettings.ProductLibrary);
        }

        private void Update()
        {
            UpdateManager.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            UpdateManager.FixedUpdate(Time.fixedDeltaTime);
        }

        private void OnDestroy()
        {
            _controller?.Dispose();
        }
    }
}
