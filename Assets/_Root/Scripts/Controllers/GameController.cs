using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class GameController : BaseController
    {
        private const string INPUT_PATH = "InputKeyboard";
        private const string CAR_PATH = "Car";
        private const string BOAT_PATH = "Boat";

        public GameController(ProfilePlayer profilePlayer)
        {
            var horizontalMove = new SubscriptionProperty<float>();
            AddController(new BackgroundController(horizontalMove, profilePlayer));
            var input = Object.Instantiate(ResourceLoader.LoadPrefab(INPUT_PATH));
            AddGameObject(input);
            input.GetComponent<BaseInputView>().Init(horizontalMove, profilePlayer.Car.Speed);
            CreateTransportController(profilePlayer);
        }

        private void CreateTransportController(ProfilePlayer profilePlayer)
        {
            switch (profilePlayer.Transport)
            {
                case Transport.Car:
                    AddGameObject(Object.Instantiate(ResourceLoader.LoadPrefab(CAR_PATH)));
                    break;
                case Transport.Boat:
                    AddGameObject(Object.Instantiate(ResourceLoader.LoadPrefab(BOAT_PATH)));
                    break;
                default:
                    Debug.LogError($"wrong transport: {profilePlayer.Transport}");
                    break;
            }
        }
    }
}
