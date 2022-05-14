using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        public void Init(UnityAction action)
        {
            _button.onClick.AddListener(action);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}
