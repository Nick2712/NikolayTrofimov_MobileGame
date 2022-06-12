using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame_Lesson9
{
    internal sealed class LoadWindowView : AssetBundleViewBase
    {
        [SerializeField] private Button _loadAssetsButton;

        private void Start()
        {
            _loadAssetsButton.onClick.AddListener(LoadAssets);
        }

        private void LoadAssets()
        {
            _loadAssetsButton.interactable = false;

            StartCoroutine(DownloadAndSetAssetBundles());
        }

        private void OnDestroy()
        {
            _loadAssetsButton.onClick.RemoveAllListeners();
        }
    }
}
