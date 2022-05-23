using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class ShedController : BaseController
    {
        private const string VIEW_PATH = "ShedView";
        private const string DATA_SOURCE_PATH = "UpgradeItemConfigDataSource";

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
            UpgradeItemConfig[] upgradeItemConfigs = ContentDataSourceLoader.LoadUpgradeItemConfigs(DATA_SOURCE_PATH);
            var repository = new UpgradeHandlersRepository(upgradeItemConfigs);
            AddRepositories(repository);

            return repository;
        }

        private InventoryController CreateInventoryController(Transform placeForUI)
        {
            var inventoryController = new InventoryController(placeForUI, _profilePlayer.InventoryModel);
            AddController(inventoryController);

            return inventoryController;
        }

        private ShedView LoadView(Transform placeForUI)
        {
            GameObject prefab = ResourceLoader.LoadPrefab(VIEW_PATH);
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
            _profilePlayer.GameState.Value = GameState.Start;
        }

        private void Back()
        {
            _profilePlayer.GameState.Value = GameState.Start;
            Debug.Log($"Back. Current speed: {_profilePlayer.Transport.Speed}");
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
    }
}
