using TMPro;
using UnityEngine;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class FightController : BaseController
    {
        private const string MONEY_TEXT = "Player money ";
        private const string HEALTH_TEXT = "Player health ";
        private const string POWER_TEXT = "Player power ";
        private const string CRIME_TEXT = "Player crime ";
        private const int ADD_INCREMENT = 1;
        private const int MINUS_INCREMENT = -1;
        private const int MAX_CRIME_VALUE = 5;
        private const int MIN_CRIME_VALUE = 0;

        private const string VIEW_PATH = "FightView";

        private const string ENEMY_DECORATION_PATH = "EnemyFightMode";
        private const string PLAYER_DECORATION_PATH = "PlayerFightMode";

        private PlayerData _money;
        private PlayerData _health;
        private PlayerData _power;
        private PlayerData _crime;

        private Enemy _enemy;
        private IEnemy _crimeListener;
        private readonly ProfilePlayer _profilePlayer;
        private readonly FightView _view;


        public FightController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView<FightView>(placeForUI, VIEW_PATH);
        
            _enemy = new Enemy("Enemy Flappy");
            _crimeListener = new CrimeListener(_view.PassPeacefully);

            _money = new PlayerData(DataType.Money);
            _health = new PlayerData(DataType.Health);
            _power = new PlayerData(DataType.Power);
            _crime = new PlayerData(DataType.Crime);
            _money.Attach(_enemy);
            _health.Attach(_enemy);
            _power.Attach(_enemy);
            _crime.Attach(_enemy);
            _crime.Attach(_crimeListener);

            Subscribe();

            InitializeView();

            LoadDecorations();
        }

        private void LoadDecorations()
        {
            AddGameObject(Object.Instantiate(ResourceLoader.LoadPrefab(PLAYER_DECORATION_PATH)));
            AddGameObject(Object.Instantiate(ResourceLoader.LoadPrefab(ENEMY_DECORATION_PATH)));
        }

        private void Subscribe()
        {
            _view.AddMoneyButton.onClick.AddListener(() => OnChangeValueButton(ADD_INCREMENT, _money));
            _view.MinusMoneyButton.onClick.AddListener(() => OnChangeValueButton(MINUS_INCREMENT, _money));
            
            _view.AddHealthButton.onClick.AddListener(() => OnChangeValueButton(ADD_INCREMENT, _health));
            _view.MinusHealthButton.onClick.AddListener(() => OnChangeValueButton(MINUS_INCREMENT, _health));
            
            _view.AddPowerButton.onClick.AddListener(() => OnChangeValueButton(ADD_INCREMENT, _power));
            _view.MinusPowerButton.onClick.AddListener(() => OnChangeValueButton(MINUS_INCREMENT, _power));
            
            _view.AddCrimeButton.onClick.AddListener(() => OnChangeValueButton(ADD_INCREMENT, _crime));
            _view.MinusCrimeButton.onClick.AddListener(() => OnChangeValueButton(MINUS_INCREMENT, _crime));
            
            _view.FightButton.onClick.AddListener(Fight);
            _view.PassPeacefully.onClick.AddListener(PassPeacefully);
        }

        private void InitializeView()
        {
            OnChangeValueButton(_view.StartMoney, _money);
            OnChangeValueButton(_view.StartHealth, _health);
            OnChangeValueButton(_view.StartPower, _power);
            OnChangeValueButton(_view.StartCrime, _crime);
        }

        private void OnChangeValueButton(int increment, PlayerData playerData)
        {
            playerData.Value += increment;

            switch (playerData.DataType)
            {
                case DataType.Money:
                    ChangeDataWindow(_view.CountMoneyText, playerData.Value, MONEY_TEXT);
                    break;
                case DataType.Health:
                    ChangeDataWindow(_view.CountHealthText, playerData.Value, HEALTH_TEXT);
                    break;
                case DataType.Power:
                    ChangeDataWindow(_view.CountPowerText, playerData.Value, POWER_TEXT);
                    break;
                case DataType.Crime:
                    if (playerData.Value > MAX_CRIME_VALUE) playerData.Value = MAX_CRIME_VALUE;
                    if (playerData.Value < MIN_CRIME_VALUE) playerData.Value = MIN_CRIME_VALUE;
                    ChangeDataWindow(_view.CountCrimeText, playerData.Value, CRIME_TEXT);
                    break;
            }
        }

        private void ChangeDataWindow(TMP_Text text, int data, string aditionalText)
        {
            text.text = $"{aditionalText}{data}";
            _view.CountPowerEnemyText.text = $"Enemy Power {_enemy.CalcPower()}";
        }

        private void Fight()
        {
            bool isWin = _power.Value >= _enemy.CalcPower();
            string message = isWin ? "Win!!!" : "Lose!!!";
            string color = isWin ? "#07FF00" : "#FF0000";

            Debug.Log($"<color={color}>{message}</color>");

            _profilePlayer.GameState.Value = GameState.Game;
        }

        private void PassPeacefully()
        {
            Debug.Log("Passed Peacefully!!!");

            _profilePlayer.GameState.Value = GameState.Game;
        }

        private void Unsubscribe()
        {
            _view.AddMoneyButton.onClick.RemoveAllListeners();
            _view.MinusMoneyButton.onClick.RemoveAllListeners();
            _view.AddHealthButton.onClick.RemoveAllListeners();
            _view.MinusHealthButton.onClick.RemoveAllListeners();
            _view.AddPowerButton.onClick.RemoveAllListeners();
            _view.MinusPowerButton.onClick.RemoveAllListeners();
            _view.AddCrimeButton.onClick.RemoveAllListeners();
            _view.MinusCrimeButton.onClick.RemoveAllListeners();
            _view.FightButton.onClick.RemoveAllListeners();
            _view.PassPeacefully.onClick.RemoveAllListeners();
        }

        protected override void OnDispose()
        {
            Unsubscribe();
            _money.Detach(_enemy);
            _health.Detach(_enemy);
            _power.Detach(_enemy);
            _crime.Detach(_enemy);
            _crime.Detach(_crimeListener);

            base.OnDispose();
        }
    }
}
