using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class SettingsController : BaseController
    {
        private const string PATH = "Settings";
        private readonly ProfilePlayer _profilePlayer;


        public SettingsController(ProfilePlayer profilePlayer, Transform placeForUI)
        {
            _profilePlayer = profilePlayer;
            var settings = Object.Instantiate(ResourceLoader.LoadPrefab(PATH), placeForUI);
            AddGameObject(settings);
            settings.GetComponent<SettingsView>().Init(Back);
        }

        private void Back()
        {
            _profilePlayer.GameState.Value = GameState.MainMenu;
        }
    }
}
