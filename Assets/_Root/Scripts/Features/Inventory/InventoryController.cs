using JetBrains.Annotations;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal class InventoryController : BaseController
    {
        

        private readonly IInventoryView _view;
        private readonly IInventoryModel _model;
        private readonly IItemsRepository _repository;

        public InventoryController(
            [NotNull] IInventoryView view, 
            [NotNull] IInventoryModel model, 
            [NotNull] IItemsRepository repository)
        {
            _view = view;
            _model = model;
            _repository = repository;

            _view.Display(_repository.Items.Values, OnItemClicked);

            foreach (string itemID in _model.EquipedItems)
                _view.Select(itemID);
        }
        
        private void OnItemClicked(string itemID)
        {
            bool equiped = _model.IsEquipped(itemID);

            if (equiped) UnequipItem(itemID);
            else EquipItem(itemID);
        }

        private void EquipItem(string itemID)
        {
            _view.Select(itemID);
            _model.EquipItem(itemID);
        }

        private void UnequipItem(string itemID)
        {
            _view.Unselect(itemID);
            _model.UnequipItem(itemID);
        }
    }
}
