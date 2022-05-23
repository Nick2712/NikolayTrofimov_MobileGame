using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class GameController : BaseController
    {
        private const string INPUT_KEYBOARD_PATH = "InputKeyboard";
        private const string INPUT_JOYSTICK_PATH = "InputJoystick";
        private const string CAR_PATH = "Car";
        private const string BOAT_PATH = "Boat";


        public GameController(ProfilePlayer profilePlayer)
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
            CreateTransportController(profilePlayer);

            UnityAnalitycTools.Instance.SendMessage("Game Started");
        }

        private void CreateTransportController(ProfilePlayer profilePlayer)
        {
            switch (profilePlayer.Transport.Type)
            {
                case Transport.Car:
                    AddGameObject(Object.Instantiate(ResourceLoader.LoadPrefab(CAR_PATH)));
                    break;
                case Transport.Boat:
                    AddGameObject(Object.Instantiate(ResourceLoader.LoadPrefab(BOAT_PATH)));
                    break;
                default:
                    Debug.LogError($"wrong transport: {profilePlayer.Transport.Type}");
                    break;
            }
        }
    }
}
