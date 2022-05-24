using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal class InventoryController : BaseController
    {
        private const string VIEW_PATH = "InventoryView";
        private const string DATA_SOURCE_PATH = "ItemConfigDataSource";

        private readonly InventoryView _inventoryView;
        private readonly IInventoryModel _model;
        private readonly ItemsRepository _repository;

        public InventoryController(Transform plaseForUI, IInventoryModel inventoryModel)
        {
            _model = inventoryModel;
            _repository = CreateRepository();
            _inventoryView = LoadView(plaseForUI);
            _inventoryView.Display(_repository.Items.Values, OnItemClicked);

            foreach (string itemID in _model.EquipedItems)
                _inventoryView.Select(itemID);
        }

        private InventoryView LoadView(Transform plaseForUI)
        {
            GameObject prefab = ResourceLoader.LoadPrefab(VIEW_PATH);
            GameObject objectView = Object.Instantiate(prefab, plaseForUI);
            AddGameObject(objectView);

            return objectView.GetComponent<InventoryView>();
        }

        private ItemsRepository CreateRepository()
        {
            ItemConfig[] itemConfigs = ContentDataSourceLoader.LoadItemConfigs(DATA_SOURCE_PATH);
            var repository = new ItemsRepository(itemConfigs);
            AddRepositories(repository);

            return repository;
        }

        private void OnItemClicked(string itemID)
        {
            bool equiped = _model.IsEquipped(itemID);

            if (equiped) UnequipItem(itemID);
            else EquipItem(itemID);
        }

        private void EquipItem(string itemID)
        {
            _inventoryView.Select(itemID);
            _model.EquipItem(itemID);
        }

        private void UnequipItem(string itemID)
        {
            _inventoryView.Unselect(itemID);
            _model.UnequipItem(itemID);
        }
    }
}
