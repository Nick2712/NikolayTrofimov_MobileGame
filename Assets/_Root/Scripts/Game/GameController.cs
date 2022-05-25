using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class GameController : BaseController
    {
        private const string INPUT_KEYBOARD_PATH = "InputKeyboard";
        private const string INPUT_JOYSTICK_PATH = "InputJoystick";
        private const string ABILITIES_VIEW_PATH = "AbilitiesView";
        private const string ABILITIES_DATA_PATH = "AbilityItemConfigDataSource";


        public GameController(ProfilePlayer profilePlayer, Transform placeForUI)
        {
            var horizontalMove = new SubscriptionProperty<float>();
            AddController(new BackgroundController(horizontalMove, profilePlayer));
#if MOBILE_INPUT
		    var input = Object.Instantiate(ResourceLoader.LoadPrefab(INPUT_JOYSTICK_PATH));
#else
            var input = Object.Instantiate(ResourceLoader.LoadPrefab(INPUT_KEYBOARD_PATH));
#endif
            AddGameObject(input);
            input.GetComponent<BaseInputView>().Init(horizontalMove, profilePlayer.Transport.Speed);
            IAbilityActivator transportController = CreateTransportController(profilePlayer);

            UnityAnalitycTools.Instance.SendMessage("Game Started");

            var abilitiesView = LoadAbilitiesView(placeForUI);
            var abilitiesItemConfigs = LoadAbilityItemConfigs();
            var abilitiesRepository = CreateAbilitiesRepository(abilitiesItemConfigs);

            var abilitiesController = new AbilitiesController(abilitiesView, abilitiesRepository, 
                abilitiesItemConfigs, transportController);
            AddController(abilitiesController);
        }

        private IAbilityActivator CreateTransportController(ProfilePlayer profilePlayer)
        {
            switch (profilePlayer.Transport.Type)
            {
                case Transport.Car:
                    var carController = new CarController();
                    AddController(carController);
                    return carController;
                case Transport.Boat:
                    var boatController = new BoatController();
                    AddController(boatController);
                    return boatController;
                default:
                    Debug.LogError($"wrong transport: {profilePlayer.Transport.Type}");
                    return null;
            }
        }

        private AbilitiesView LoadAbilitiesView(Transform placeForUI)
        {
            GameObject prefab = ResourceLoader.LoadPrefab(ABILITIES_VIEW_PATH);
            GameObject objectView = Object.Instantiate(prefab, placeForUI, false);
            AddGameObject(objectView);

            return objectView.GetComponent<AbilitiesView>();
        }

        private AbilitiesRepository CreateAbilitiesRepository(AbilityItemConfig[] abilityItemConfig)
        {
            var repository = new AbilitiesRepository(abilityItemConfig);
            AddRepositories(repository);

            return repository;
        }

        private AbilityItemConfig[] LoadAbilityItemConfigs()
        {
            return ContentDataSourceLoader.LoadAbilityItemConfigs(ABILITIES_DATA_PATH);
        }
    }
}
