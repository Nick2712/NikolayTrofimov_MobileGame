using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class SettingsView : MonoBehaviour
    {
        private const int RUSSIAN_INDEX = 0;
        private const int ENGLISH_INDEX = 1;

        [SerializeField] private Button _backButton;
        [SerializeField] private TMP_Dropdown _languageSelector;

        private SubscriptionProperty<Language> _onLanguageChanged;


        public void Init(UnityAction backAction, SubscriptionProperty<Language> onLanguageChanged)
        {
            _backButton.onClick.AddListener(backAction);
            _onLanguageChanged = onLanguageChanged;

            _languageSelector.onValueChanged.AddListener(OnLanguageSelected);

            SetLaguageSelectorPosition();
        }

        private void SetLaguageSelectorPosition()
        {
            switch(_onLanguageChanged.Value)
            {
                case Language.English:
                    _languageSelector.SetValueWithoutNotify(ENGLISH_INDEX);
                    break;
                case Language.Russian:
                    _languageSelector.SetValueWithoutNotify(RUSSIAN_INDEX);
                    break;
                default:
                    _languageSelector.SetValueWithoutNotify(ENGLISH_INDEX);
                    break;
            }
        }

        private void OnLanguageSelected(int index)
        {
            switch (index)
            {
                case RUSSIAN_INDEX:
                    _onLanguageChanged.Value = Language.Russian;
                    break;
                case ENGLISH_INDEX:
                    _onLanguageChanged.Value = Language.English;
                    break;
                default:
                    _onLanguageChanged.Value = Language.English;
                    break;
            }
        }

        private void OnDestroy()
        {
            _backButton.onClick.RemoveAllListeners();
            _languageSelector.onValueChanged.RemoveAllListeners();
        }
    }
}
