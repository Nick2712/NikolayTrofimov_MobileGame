using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class MainMenuView : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _dailyRewardButton;
        [SerializeField] private Button _shedButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _showRewardedButton;
        [SerializeField] private Button _buyProductButton;

        
        public void Init(UnityAction startAction, UnityAction settingsAction, 
            UnityAction showRewardedAction, UnityAction buyProductAction, UnityAction shedAction, 
            UnityAction dailyRewardAction, UnityAction exitAction)
        {
            _startButton.onClick.AddListener(startAction);
            _settingsButton.onClick.AddListener(settingsAction);
            _showRewardedButton.onClick.AddListener(showRewardedAction);
            _exitButton.onClick.AddListener(exitAction);
            _shedButton.onClick.AddListener(shedAction);
            _dailyRewardButton.onClick.AddListener(dailyRewardAction);
            _buyProductButton.onClick.AddListener(buyProductAction);
        }

        private void OnDestroy()
        {
            _startButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
            _showRewardedButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
            _shedButton.onClick.RemoveAllListeners();
            _dailyRewardButton.onClick.RemoveAllListeners();
            _buyProductButton.onClick.RemoveAllListeners();
        }
    }
}
