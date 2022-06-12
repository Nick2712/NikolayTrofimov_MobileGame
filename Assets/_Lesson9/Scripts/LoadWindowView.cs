using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame_Lesson9
{
    internal sealed class LoadWindowView : AssetBundleViewBase
    {
        [Header("Asset Bundles")]
        [SerializeField] private Button _loadAssetsButton;

        [Header("Addressables")]
        [SerializeField] private AssetReference _spawningButtonPrefab;
        [SerializeField] private RectTransform _spawnedButtonConteiner;
        [SerializeField] private Button _spawnAssetButton;

        [Header("Lesson9 DZ1")]
        [SerializeField] private Button _dzButton;

        [Header("Lesson9 DZ2")]
        [SerializeField] private AssetReference _backgroundImagePrefab;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Button _addBackgroundButton;
        [SerializeField] private Button _removeBackgroundButton;

        private readonly List<AsyncOperationHandle<GameObject>> _addressablePrefabs = 
            new List<AsyncOperationHandle<GameObject>>();

        private AsyncOperationHandle<Sprite> _addressableDackgroundSprite;


        private void Start()
        {
            _loadAssetsButton.onClick.AddListener(LoadAssets);
            _spawnAssetButton.onClick.AddListener(SpawnPrefab);

            _dzButton.onClick.AddListener(ChangeImage);

            _addBackgroundButton.onClick.AddListener(AddBackground);
            _removeBackgroundButton.onClick.AddListener(RemoveBackground);

            _removeBackgroundButton.interactable = false;
        }

        private void AddBackground()
        {
            _addBackgroundButton.interactable = false;
            _removeBackgroundButton.interactable = true;

            _backgroundImage.gameObject.SetActive(true);

            _addressableDackgroundSprite = Addressables.LoadAssetAsync<Sprite>(_backgroundImagePrefab);

            _backgroundImage.sprite = _addressableDackgroundSprite.WaitForCompletion();
        }


        private void RemoveBackground()
        {
            _addBackgroundButton.interactable = true;
            _removeBackgroundButton.interactable= false;

            Addressables.Release(_addressableDackgroundSprite);
            _backgroundImage.sprite= null;

            _backgroundImage.gameObject.SetActive(false);
        }

        private void ChangeImage()
        {
            _dzButton.interactable = false;

            StartCoroutine(DZ());
        }

        private void SpawnPrefab()
        {
            AsyncOperationHandle<GameObject> addressablePrefab = 
                Addressables.InstantiateAsync(_spawningButtonPrefab, _spawnedButtonConteiner);

            _addressablePrefabs.Add(addressablePrefab);
        }

        private void DespawnPrefabs()
        {
            foreach (AsyncOperationHandle<GameObject> addressablePrefab in _addressablePrefabs)
                Addressables.ReleaseInstance(addressablePrefab);

            _addressablePrefabs.Clear();
        }

        private void LoadAssets()
        {
            _loadAssetsButton.interactable = false;

            StartCoroutine(DownloadAndSetAssetBundles());
        }

        private void OnDestroy()
        {
            _loadAssetsButton.onClick.RemoveAllListeners();
            _spawnAssetButton.onClick.RemoveAllListeners();

            _dzButton.onClick.RemoveAllListeners();

            DespawnPrefabs();

            Addressables.Release(_addressableDackgroundSprite);
        }
    }
}
