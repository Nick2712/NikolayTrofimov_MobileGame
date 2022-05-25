using JetBrains.Annotations;
using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class AbilitiesController : BaseController
    {
        private readonly IAbilitiesView _view;
        private readonly IAbilitiesRepository _repository;
        private readonly IAbilityActivator _activator;


        public AbilitiesController(
            [NotNull] IAbilitiesView view, 
            [NotNull] IAbilitiesRepository repository,
            [NotNull] IEnumerable<IAbilityItem> items,
            [NotNull] IAbilityActivator activator)
        {
            _view = view;
            _repository = repository;
            _activator = activator;
            
            _view.Display(items, OnAbilityViewClicked);
        }

        private void OnAbilityViewClicked(string abilityID)
        {
            if (_repository.Items.TryGetValue(abilityID, out IAbility ability))
                ability.Apply(_activator);
        }
    }
}
