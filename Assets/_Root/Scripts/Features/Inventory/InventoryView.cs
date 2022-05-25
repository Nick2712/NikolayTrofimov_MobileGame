using System;
using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal class InventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField] private GameObject _itemViewPrefab;
        [SerializeField] private Transform _placeForItems;

        private readonly Dictionary<string, ItemView> _itemsViews = new ();

        public void Display(IEnumerable<IItem> itemsCollection, Action<string> itemClicked)
        {
            Clear();

            foreach(ItemConfig item in itemsCollection)
            {
                _itemsViews[item.Id] = CreateItemView(item, itemClicked);
            }
        }

        public void Clear()
        {
            foreach(ItemView itemView in _itemsViews.Values)
            {
                DestroyItemView(itemView);
            }

            _itemsViews.Clear();
        }

        private ItemView CreateItemView(ItemConfig item, Action<string> itemClicked)
        {
            GameObject objectView = Instantiate(_itemViewPrefab, _placeForItems, false);
            ItemView itemView = objectView.GetComponent<ItemView>();

            itemView.Init(item, () => itemClicked?.Invoke(item.Id));
            return itemView;
        }

        public void Select(string id)
        {
            _itemsViews[id].Select();
        }

        public void Unselect(string id)
        {
            _itemsViews[id].Unselect();
        }

        private void DestroyItemView(ItemView itemView)
        {
            itemView.Deinit();
            Destroy(itemView.gameObject);
        }

        private void OnDestroy()
        {
            Clear();
        }
    }
}
