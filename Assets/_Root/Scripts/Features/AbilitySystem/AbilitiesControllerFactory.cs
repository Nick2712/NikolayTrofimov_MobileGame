using System;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class AbilitiesControllerFactory
    {
        private const string VIEW_PATH = "AbilitiesView";
        private const string DATA_PATH = "AbilityItemConfigDataSource";

        private readonly Transform _placeForUI;


        public AbilitiesControllerFactory(Transform placeForUI)
        {
            _placeForUI = placeForUI;
        }

        public AbilitiesController Create(Action<IRepository> addRepositoryAction, Action<GameObject> addGameObjectAction, 
            IAbilityActivator abilityActivator)
        {
            var abilitiesView = LoadAbilitiesView(_placeForUI, addGameObjectAction);
            var abilitiesItemConfigs = LoadAbilityItemConfigs();
            var abilitiesRepository = CreateAbilitiesRepository(abilitiesItemConfigs, addRepositoryAction);

            return new AbilitiesController(abilitiesView, abilitiesRepository, abilitiesItemConfigs, abilityActivator);
        }

        private AbilitiesView LoadAbilitiesView(Transform placeForUI, Action<GameObject> addGameObjectAction)
        {
            GameObject prefab = ResourceLoader.LoadPrefab(VIEW_PATH);
            GameObject objectView = UnityEngine.Object.Instantiate(prefab, placeForUI, false);
            addGameObjectAction(objectView);

            return objectView.GetComponent<AbilitiesView>();
        }

        private AbilitiesRepository CreateAbilitiesRepository(AbilityItemConfig[] abilityItemConfig,
            Action<IRepository> addRepositoryAction)
        {
            var repository = new AbilitiesRepository(abilityItemConfig);
            addRepositoryAction(repository);

            return repository;
        }

        private AbilityItemConfig[] LoadAbilityItemConfigs()
        {
            return ContentDataSourceLoader.LoadAbilityItemConfigs(DATA_PATH);
        }
    }
}
