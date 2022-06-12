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

        private readonly List<AsyncOperationHandle<GameObject>> _addressablePrefabs = 
            new List<AsyncOperationHandle<GameObject>>();


        private void Start()
        {
            _loadAssetsButton.onClick.AddListener(LoadAssets);
            _spawnAssetButton.onClick.AddListener(SpawnPrefab);

            _dzButton.onClick.AddListener(ChangeImage);
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
        }
    }
}
