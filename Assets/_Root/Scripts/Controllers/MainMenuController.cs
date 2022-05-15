using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class MainMenuController : BaseController
    {
        private const string PATH = "MainMenu";

        private readonly ProfilePlayer _profilePlayer;


        public MainMenuController(ProfilePlayer profilePlayer, Transform placeForUI)
        {
            _profilePlayer = profilePlayer;
            var mainMenu = Object.Instantiate(ResourceLoader.LoadPrefab(PATH), placeForUI);
            mainMenu.GetComponent<MainMenuView>().Init(StartGame, Settings);
            AddGameObject(mainMenu);
        }

        private void StartGame()
        {
            _profilePlayer.GameState.Value = GameState.Game;
        }

        private void Settings()
        {
            _profilePlayer.GameState.Value = GameState.Settings;
        }
    }
}
