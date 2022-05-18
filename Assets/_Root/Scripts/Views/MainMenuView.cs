using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _showRewarded;
        
        public void Init(UnityAction startAction, UnityAction settingsAction, UnityAction showRewarded)
        {
            _startButton.onClick.AddListener(startAction);
            _settingsButton.onClick.AddListener(settingsAction);
            _showRewarded.onClick.AddListener(showRewarded);
        }

        private void OnDestroy()
        {
            _startButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
            _showRewarded.onClick.RemoveAllListeners();
        }
    }
}
