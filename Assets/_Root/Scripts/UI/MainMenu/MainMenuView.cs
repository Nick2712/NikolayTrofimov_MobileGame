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
        [SerializeField] private Button _purchaseSomething;
        [SerializeField] private Button _shedButton;
        
        public void Init(UnityAction startAction, UnityAction settingsAction, 
            UnityAction showRewarded, UnityAction purchaseSomething, UnityAction shed)
        {
            _startButton.onClick.AddListener(startAction);
            _settingsButton.onClick.AddListener(settingsAction);
            _showRewarded.onClick.AddListener(showRewarded);
            _purchaseSomething.onClick.AddListener(purchaseSomething);
            _shedButton.onClick.AddListener(shed);
        }

        private void OnDestroy()
        {
            _startButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
            _showRewarded.onClick.RemoveAllListeners();
            _purchaseSomething.onClick.RemoveAllListeners();
            _shedButton.onClick.RemoveAllListeners();
        }
    }
}
