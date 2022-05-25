using System;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class InventoryControllerFactory
    {
        private const string VIEW_PATH = "InventoryView";
        private const string DATA_SOURCE_PATH = "ItemConfigDataSource";

        private readonly ProfilePlayer _profilePlayer;
        private readonly Transform _placeForUI;

        public InventoryControllerFactory(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _placeForUI = placeForUI;
            _profilePlayer = profilePlayer;
        }

        public InventoryController Create(Action<IRepository> addRepositoryAction, Action<GameObject> addGameObjectAction)
        {
            var inventoryView = LoadInventoryView(_placeForUI, addGameObjectAction);
            var inventoryRepository = CreateInventoryRepository(addRepositoryAction);
            return new InventoryController(inventoryView, _profilePlayer.InventoryModel, inventoryRepository);
        }

        private InventoryView LoadInventoryView(Transform plaseForUI, Action<GameObject> addGameObjectActoin)
        {
            GameObject prefab = ResourceLoader.LoadPrefab(VIEW_PATH);
            GameObject objectView = UnityEngine.Object.Instantiate(prefab, plaseForUI);
            addGameObjectActoin(objectView);

            return objectView.GetComponent<InventoryView>();
        }

        private ItemsRepository CreateInventoryRepository(Action<IRepository> addRepositoryAction)
        {
            ItemConfig[] itemConfigs = ContentDataSourceLoader.LoadItemConfigs(DATA_SOURCE_PATH);
            var repository = new ItemsRepository(itemConfigs);
            addRepositoryAction(repository);

            return repository;
        }
    }
}
