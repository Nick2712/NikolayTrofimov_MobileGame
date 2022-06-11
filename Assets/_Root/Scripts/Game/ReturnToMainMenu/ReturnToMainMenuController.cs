using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class ReturnToMainMenuController : BaseController
    {
        private const string VIEW_PATH = "ReturnToMainMenu";

        private readonly ProfilePlayer _profilePlayer;
        private readonly ReturnToMainMenuView _view;


        public ReturnToMainMenuController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;

            _view = LoadView<ReturnToMainMenuView>(placeForUI, VIEW_PATH);
            _view.ReturnToMainMenuButton.onClick.AddListener(ReturnToMainMenu);
        }

        private void ReturnToMainMenu()
        {
            _profilePlayer.GameState.Value = GameState.MainMenu;
        }

        protected override void OnDispose()
        {
            _view.ReturnToMainMenuButton.onClick.RemoveListener(ReturnToMainMenu);

            base.OnDispose();
        }
    }
}
