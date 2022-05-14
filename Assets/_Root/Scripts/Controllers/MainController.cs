using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class MainController : BaseController
    {
        private const GameState INIT_GAME_STATE = GameState.Start;
        
        private readonly ProfilePlayer _profilePlayer;
        private readonly Transform _placeForUI;
        private MainMenuController _mainMenuController;
        private GameController _gameController;

        public MainController(Transform placeForUI, float speed)
        {
            _profilePlayer = new ProfilePlayer(speed);
            _profilePlayer.GameState.Subscribe(OnGameStateChange);
            _placeForUI = placeForUI;
            _profilePlayer.GameState.Value = INIT_GAME_STATE;
        }

        private void OnGameStateChange(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Start:
                    _gameController?.Dispose();
                    _mainMenuController = new MainMenuController(_profilePlayer, _placeForUI);
                    break;
                case GameState.Game:
                    _mainMenuController?.Dispose();
                    _gameController = new GameController(_profilePlayer);
                    break;
                default:
                    DisposeAll();
                    break;
            }
        }

        private void DisposeAll()
        {
            _gameController?.Dispose();
            _mainMenuController?.Dispose();
        }

        protected override void OnDispose()
        {
            _profilePlayer.GameState.Unsubscribe(OnGameStateChange);
            DisposeAll();
        }
    }
}
