using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class SettingsView : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        
        public void Init(UnityAction backAction)
        {
            _backButton.onClick.AddListener(backAction);
        }

        private void OnDestroy()
        {
            _backButton.onClick.RemoveAllListeners();
        }
    }
}
