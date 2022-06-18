using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.ResourceManagement.AsyncOperations;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class MainMenuLocalization : MonoBehaviour
    {
        [SerializeField] private string _tabName;
        [SerializeField] private LocalizationOptions[] _localizationOptions;

        private SubscriptionProperty<Language> _onLanguageChanged;


        public void Init(SubscriptionProperty<Language> onLanguageChanged)
        {
            _onLanguageChanged = onLanguageChanged;

            LocalizationSettings.SelectedLocaleChanged += OnSelectedLocaleChanged;

            //костыль. Еле придумал, как заставить работать.
            if(LocalizationSettings.SelectedLocale != null)
                LocalizationSettings.Instance.SetSelectedLocale(
                    LocalizationSettings.AvailableLocales.Locales[GetIndextLanguage(_onLanguageChanged.Value)]);
            else
                StartCoroutine(ChangingLocaleRoutine());
            //
        }

        private void OnDestroy()
        {
            LocalizationSettings.SelectedLocaleChanged -= OnSelectedLocaleChanged;
        }

        private void OnSelectedLocaleChanged(Locale _) =>
            StartCoroutine(ChangingLocaleRoutine());

        private IEnumerator ChangingLocaleRoutine()
        {
            AsyncOperationHandle<StringTable> loadingOperation = LocalizationSettings.StringDatabase.GetTableAsync(_tabName);
            yield return loadingOperation;

            if (loadingOperation.Status == AsyncOperationStatus.Succeeded)
            {
                StringTable table = loadingOperation.Result;

                foreach (var option in _localizationOptions)
                {
                    option.TextField.text = table.GetEntry(option.Key)?.GetLocalizedString();
                }
            }
            else
            {
                string errorMessage = $"[{GetType().Name}] Could not load String Table: {loadingOperation.OperationException}";
                Debug.LogError(errorMessage);
            }
        }

        private int GetIndextLanguage(Language language)
        {
            return language switch
            {
                Language.English => 0,
                Language.Russian => 1,
                _ => 0,
            };
        }
    }
}
