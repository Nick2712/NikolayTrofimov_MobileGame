using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class AbilityButtonView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;


        public void Init(Sprite icon, UnityAction click)
        {
            _icon.sprite = icon;
            _button.onClick.AddListener(click);
        }

        public void Deinit()
        {
            _icon.sprite = null;
            _button.onClick.RemoveAllListeners();
        }

        private void OnDestroy()
        {
            Deinit();
        }
    }
}
