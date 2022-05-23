using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class GameController : BaseController
    {
        private const string INPUT_KEYBOARD_PATH = "InputKeyboard";
        private const string INPUT_JOYSTICK_PATH = "InputJoystick";
        private const string CAR_PATH = "Car";
        private const string BOAT_PATH = "Boat";


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

            var abilitiesController = new AbilitiesController(placeForUI, transportController);
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
    }
}
