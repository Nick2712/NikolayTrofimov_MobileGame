using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class MainController : BaseController
    {
        private const GameState INIT_GAME_STATE = GameState.MainMenu;
        
        private readonly ProfilePlayer _profilePlayer;
        private readonly Transform _placeForUI;
        private BaseController _currentStateController;


        public MainController(Transform placeForUI, float speed, float jumpHeight, Transport transport)
        {
            _profilePlayer = new ProfilePlayer(speed, jumpHeight, transport);
            _profilePlayer.GameState.Subscribe(OnGameStateChange);
            _placeForUI = placeForUI;
            _profilePlayer.GameState.Value = INIT_GAME_STATE;
        }

        private void OnGameStateChange(GameState gameState)
        {
            _currentStateController?.Dispose();
            switch (gameState)
            {
                case GameState.MainMenu:
                    _currentStateController = new MainMenuController(_profilePlayer, _placeForUI);
                    break;
                case GameState.Game:
                    _currentStateController = new GameController(_profilePlayer, _placeForUI);
                    break;
                case GameState.Settings:
                    _currentStateController = new SettingsController(_profilePlayer, _placeForUI);
                    break;
                case GameState.Inventory:
                    _currentStateController = new ShedController(_placeForUI, _profilePlayer);
                    break;
                case GameState.DailyReward:
                    _currentStateController = new RewardController(_placeForUI, _profilePlayer);
                    break;
            }
        }

        protected override void OnDispose()
        {
            _profilePlayer.GameState.Unsubscribe(OnGameStateChange);
            _currentStateController?.Dispose();
        }
    }
}
