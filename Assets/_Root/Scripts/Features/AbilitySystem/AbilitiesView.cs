using System;
using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class AbilitiesView : MonoBehaviour
    {
        [SerializeField] private GameObject _abilityButtonPrefab;
        [SerializeField] private Transform _placeForButtons;

        private readonly Dictionary<string, AbilityButtonView> _buttonViews = new Dictionary<string, AbilityButtonView>();

        public void Display(IReadOnlyList<IAbilityItem> abilityItems, Action<string> clicked)
        {
            Clear();

            foreach (IAbilityItem abilityItem in abilityItems)
                _buttonViews[abilityItem.Id] = CreateButtonView(abilityItem, clicked);
        }

        private AbilityButtonView CreateButtonView(IAbilityItem abilityItem, Action<string> clicked)
        {
            GameObject objectView = Instantiate(_abilityButtonPrefab, _placeForButtons, false);
            AbilityButtonView buttonView = objectView.GetComponent<AbilityButtonView>();

            buttonView.Init(abilityItem.Icon, () => clicked?.Invoke(abilityItem.Id));

            return buttonView;
        }

        public void Clear()
        {
            foreach(AbilityButtonView buttonView in _buttonViews.Values)
                DestroyButtonView(buttonView);

            _buttonViews.Clear();
        }

        private void DestroyButtonView(AbilityButtonView buttonView)
        {
            buttonView.Deinit();
            Destroy(buttonView.gameObject);
        }
    }
}
