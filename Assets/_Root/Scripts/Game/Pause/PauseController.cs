using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class PauseController : BaseController
    {
        private const string VIEW_PATH = "Pause";

        private readonly ProfilePlayer _profilePlayer;
        private readonly PauseView _view;

        public PauseController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView<PauseView>(placeForUI, VIEW_PATH);
            _view.MenuPausePrefab.SetActive(false);

            Subscribe();
        }

        private void Subscribe()
        {
            _view.PauseButton.onClick.AddListener(Pause);
            _view.ReturnToMainMenuButton.onClick.AddListener(ReturnToMainMenu);
            _view.ContinueButton.onClick.AddListener(Continue);
        }

        private void Unsubscribe()
        {
            _view.PauseButton.onClick.RemoveListener(Pause);
            _view.ReturnToMainMenuButton.onClick.RemoveListener(ReturnToMainMenu);
            _view.ContinueButton.onClick.RemoveListener(Continue);
        }

        private void ReturnToMainMenu()
        {
            Time.timeScale = 1;

            _profilePlayer.GameState.Value = GameState.MainMenu;
        }

        private void Continue()
        {
            Time.timeScale = 1;
            _profilePlayer.Pause.OnPause.Value = false;

            _view.MenuPausePrefab.SetActive(false);
        }

        private void Pause()
        {
            Time.timeScale = 0;
            _profilePlayer.Pause.OnPause.Value = true;

            _view.MenuPausePrefab.SetActive(true);
        }

        protected override void OnDispose()
        {
            Unsubscribe();
            Time.timeScale = 1;
            _profilePlayer.Pause.OnPause.Value = false;

            base.OnDispose();
        }
    }
}
