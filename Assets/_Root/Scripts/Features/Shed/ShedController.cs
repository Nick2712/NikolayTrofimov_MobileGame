using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class ShedController : BaseController
    {
        private const string SHED_VIEW_PATH = "ShedView";
        private const string SHED_DATA_SOURCE_PATH = "UpgradeItemConfigDataSource";
        private const string INVENTORY_VIEW_PATH = "InventoryView";
        private const string iNVENTORY_DATA_SOURCE_PATH = "ItemConfigDataSource";

        private readonly ShedView _view;
        private readonly ProfilePlayer _profilePlayer;
        private readonly InventoryController _inventoryController;
        private readonly UpgradeHandlersRepository _upgradeHandlersRepository;

        public ShedController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _upgradeHandlersRepository = CreateRepository();
            _inventoryController = CreateInventoryController(placeForUI);
            _view = LoadView(placeForUI);

            _view.Init(Apply, Back);
        }

        private UpgradeHandlersRepository CreateRepository()
        {
            UpgradeItemConfig[] upgradeItemConfigs = ContentDataSourceLoader.LoadUpgradeItemConfigs(SHED_DATA_SOURCE_PATH);
            var repository = new UpgradeHandlersRepository(upgradeItemConfigs);
            AddRepositories(repository);

            return repository;
        }

        private InventoryController CreateInventoryController(Transform placeForUI)
        {
            var inventoryView = LoadInventoryView(placeForUI);
            var inventoryRepository = CreateInventoryRepository();
            var inventoryController = new InventoryController(inventoryView, 
                _profilePlayer.InventoryModel, inventoryRepository);
            AddController(inventoryController);

            return inventoryController;
        }

        private ShedView LoadView(Transform placeForUI)
        {
            GameObject prefab = ResourceLoader.LoadPrefab(SHED_VIEW_PATH);
            GameObject objectView = Object.Instantiate(prefab, placeForUI, false);
            AddGameObject(objectView);

            return objectView.GetComponent<ShedView>();
        }

        private void Apply()
        {
            _profilePlayer.Transport.Restore();

            UpgradeWithEquippedItems(_profilePlayer.Transport,
                _profilePlayer.InventoryModel.EquipedItems, _upgradeHandlersRepository.Items);

            Debug.Log($"Aply. Current speed {_profilePlayer.Transport.Speed}");
            Debug.Log($"Aply. Current jump height {_profilePlayer.Transport.JumpHeight}");
            _profilePlayer.GameState.Value = GameState.MainMenu;
        }

        private void Back()
        {
            _profilePlayer.GameState.Value = GameState.MainMenu;
            Debug.Log($"Back. Current speed: {_profilePlayer.Transport.Speed}");
            Debug.Log($"Back. Current jump height: {_profilePlayer.Transport.JumpHeight}");
        }

        private void UpgradeWithEquippedItems(TransportModel transport, IReadOnlyList<string> equipedItems,
            IReadOnlyDictionary<string, IUpgradeHandler> items)
        {
            foreach(string itemID in equipedItems)
            {
                if (items.TryGetValue(itemID, out IUpgradeHandler upgradeHandler))
                    upgradeHandler.Upgrade(transport);
            }
        }

        private InventoryView LoadInventoryView(Transform plaseForUI)
        {
            GameObject prefab = ResourceLoader.LoadPrefab(INVENTORY_VIEW_PATH);
            GameObject objectView = Object.Instantiate(prefab, plaseForUI);
            AddGameObject(objectView);

            return objectView.GetComponent<InventoryView>();
        }

        private ItemsRepository CreateInventoryRepository()
        {
            ItemConfig[] itemConfigs = ContentDataSourceLoader.LoadItemConfigs(iNVENTORY_DATA_SOURCE_PATH);
            var repository = new ItemsRepository(itemConfigs);
            AddRepositories(repository);

            return repository;
        }
    }
}
