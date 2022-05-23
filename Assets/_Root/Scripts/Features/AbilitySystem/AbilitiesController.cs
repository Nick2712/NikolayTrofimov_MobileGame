using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class AbilitiesController : BaseController
    {
        private const string VIEW_PATH = "AbilitiesView";
        private const string DATA_RESOURCE_PATH = "AbilityItemConfigDataSource";

        private readonly AbilitiesView _abilitiesView;
        private readonly AbilitiesRepository _repository;
        private readonly IAbilityActivator _abilityActivator;


        public AbilitiesController(Transform placeForUI, IAbilityActivator activator)
        {
            _abilityActivator = activator;
            var abilityItemConfig = LoadAbilityItemConfigs();
            _repository = CreateRepository(abilityItemConfig);
            _abilitiesView = LoadView(placeForUI);

            _abilitiesView.Display(abilityItemConfig, OnAbilityViewClicked);
        }

        private void OnAbilityViewClicked(string abilityID)
        {
            if (_repository.Items.TryGetValue(abilityID, out IAbility ability))
                ability.Apply(_abilityActivator);
        }

        private AbilitiesView LoadView(Transform placeForUI)
        {
            GameObject prefab = ResourceLoader.LoadPrefab(VIEW_PATH);
            GameObject objectView = Object.Instantiate(prefab, placeForUI, false);
            AddGameObject(objectView);

            return objectView.GetComponent<AbilitiesView>();
        }

        private AbilitiesRepository CreateRepository(AbilityItemConfig[] abilityItemConfig)
        {
            var repository = new AbilitiesRepository(abilityItemConfig);
            AddRepositories(repository);

            return repository;
        }

        private AbilityItemConfig[] LoadAbilityItemConfigs()
        {
            return ContentDataSourceLoader.LoadAbilityItemConfigs(DATA_RESOURCE_PATH);
        }
    }
}
