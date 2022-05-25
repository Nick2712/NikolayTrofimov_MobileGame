using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class ShedView : MonoBehaviour, IShedView
    {
        [SerializeField] private Button _applyButton;
        [SerializeField] private Button _backButton;

        public void Init(UnityAction apply, UnityAction back)
        {
            _applyButton.onClick.AddListener(apply);
            _backButton.onClick.AddListener(back);
        }

        public void Deinit()
        {
            _applyButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
        }

        private void OnDestroy()
        {
            Deinit();
        }
    }
}
