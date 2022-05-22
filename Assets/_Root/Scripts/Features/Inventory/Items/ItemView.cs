using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame
{
    internal class ItemView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private CustomText _title;
        [SerializeField] private Button _button;

        [SerializeField] private GameObject _selectedBackground;
        [SerializeField] private GameObject _unselectedBackground;


        public void Init(ItemConfig item, UnityAction action)
        {
            _title.Text = item.Title;
            _icon.sprite = item.Icon;
            _button.onClick.AddListener(action);
        }

        public void Deinit()
        {
            _title.Text = string.Empty;
            _icon.sprite = null;
            _button.onClick.RemoveAllListeners();
        }

        public void Select() => SetSelected(true);
        public void Unselect() => SetSelected(false);

        private void SetSelected(bool isSelected)
        {
            _selectedBackground.SetActive(isSelected);
            _unselectedBackground.SetActive(!isSelected);
        }

        private void OnDestroy()
        {
            Deinit();
        }
    }
}
