using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame_Lesson10
{
    internal abstract class LocalizationWindow : MonoBehaviour
    {
        [Header("Scene components")]
        [SerializeField] private Button _englishButton;
        [SerializeField] private Button _frenchButton;
        [SerializeField] private Button _russianButton;

        private void Start()
        {
            _englishButton.onClick.AddListener(() => ChangeLanguage(0));
            _frenchButton.onClick.AddListener(() => ChangeLanguage(1));
            _russianButton.onClick.AddListener(() => ChangeLanguage(2));
            OnStarted();
        }

        private void OnDestroy()
        {
            _englishButton.onClick.RemoveAllListeners();
            _frenchButton.onClick.RemoveAllListeners();
            _russianButton.onClick.RemoveAllListeners();
            OnDestroyed();
        }

        protected virtual void OnDestroyed() { }
        protected virtual void OnStarted() { }

        private void ChangeLanguage(int index) =>
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
