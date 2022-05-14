using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class GameController : BaseController
    {
        private const string INPUT_PATH = "InputKeyboard";
        private const string CAR_PATH = "Car";

        public GameController(ProfilePlayer profilePlayer)
        {
            var horizontalMove = new SubscriptionProperty<float>();
            AddController(new BackgroundController(horizontalMove, profilePlayer));
            var input = Object.Instantiate(ResourceLoader.LoadPrefab(INPUT_PATH));
            AddGameObject(input);
            input.GetComponent<BaseInputView>().Init(horizontalMove, profilePlayer.Car.Speed);
            var car = Object.Instantiate(ResourceLoader.LoadPrefab(CAR_PATH));
            AddGameObject(car);
        }
    }
}
