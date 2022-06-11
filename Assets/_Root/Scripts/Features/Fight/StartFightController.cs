using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class StartFightController : BaseController
    {
        private const string VIEW_PATH = "StartFightView";

        private readonly StartFightView _view;
        private readonly ProfilePlayer _profilePlayer;


        public StartFightController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView<StartFightView>(placeForUI, VIEW_PATH);

            Subscribe();
        }

        private void Subscribe()
        {
            _view.StartFightButton.onClick.AddListener(StartFight);
        }

        private void Unsubscribe()
        {
            _view.StartFightButton.onClick.RemoveListener(StartFight);
        }

        private void StartFight()
        {
            _profilePlayer.GameState.Value = GameState.Fight;
        }

        protected override void OnDispose()
        {
            Unsubscribe();

            base.OnDispose();
        }
    }
}
