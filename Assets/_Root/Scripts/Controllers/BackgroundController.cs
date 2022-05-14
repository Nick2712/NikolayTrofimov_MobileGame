using UnityEngine;

namespace NikolayTrofimov_MobileGame
{
    internal sealed class BackgroundController : BaseController
    {
        private const string PATH = "Background";
        private readonly BackgroundView _backgroundView;
        private ISubscriptionProperty<float> _horizontalMove;
        private readonly ProfilePlayer _profilePlayer;

        public BackgroundController(ISubscriptionProperty<float> horizontalMove, ProfilePlayer profilePlayer)
        {
            var background = Object.Instantiate(ResourceLoader.LoadPrefab(PATH));
            AddGameObject(background);
            _horizontalMove = horizontalMove;
            _backgroundView = background.GetComponent<BackgroundView>();
            UpdateManager.FixedUpdateAction += Move;
            _profilePlayer = profilePlayer;
        }

        private void Move(float fixedDeltaTime)
        {
            _backgroundView.Move(_horizontalMove.Value * _profilePlayer.Car.Speed * fixedDeltaTime);
        }

        protected override void OnDispose()
        {
            UpdateManager.FixedUpdateAction -= Move;
        }
    }
}
