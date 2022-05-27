using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace NikolayTrofimov_MobileGame_Lesson5
{
    internal sealed class MainWindowObserver : MonoBehaviour
    {
        private const string MONEY_TEXT = "Player money ";
        private const string HEALTH_TEXT = "Player health ";
        private const string POWER_TEXT = "Player power ";
        private const int ADD_INCREMENT = 1;
        private const int MINUS_INCREMENT = -1;

        [Header("Player Stats")]
        [SerializeField] private TMP_Text _countMoneyText;
        [SerializeField] private TMP_Text _countHealthText;
        [SerializeField] private TMP_Text _countPowerText;
        [Header("Enemy Stats")]
        [SerializeField] private TMP_Text _countPowerEnemyText;

        [Header("Money Buttons")]
        [SerializeField] private Button _addMoneyButton;
        [SerializeField] private Button _minusMoneyButton;


        [Header("Health Buttons")]
        [SerializeField] private Button _addHealthButton;
        [SerializeField] private Button _minusHealthButton;

        [Header("Power Buttons")]
        [SerializeField] private Button _addPowerButton;
        [SerializeField] private Button _minusPowerButton;

        [Header("Other Buttons")]
        [SerializeField] private Button _fightButton;

        [Header("Starting Player Parametres")]
        [SerializeField] private int _startMoney = 1000;
        [SerializeField] private int _startHealth = 100;
        [SerializeField] private int _startPower = 1;

        private PlayerData _money;
        private PlayerData _health;
        private PlayerData _power;

        private Enemy _enemy;


        private void Start()
        {
            _enemy = new Enemy("Enemy Flappy");

            _money = new PlayerData(DataType.Money);
            _health = new PlayerData(DataType.Health);
            _power = new PlayerData(DataType.Power);
            _money.Attach(_enemy);
            _health.Attach(_enemy);
            _power.Attach(_enemy);

            Subscribe();

            InitializeView();
        }

        private void Subscribe()
        {
            _addMoneyButton.onClick.AddListener(() => OnChangeValueButton(ADD_INCREMENT, _money));
            _minusMoneyButton.onClick.AddListener(() => OnChangeValueButton(MINUS_INCREMENT, _money));

            _addHealthButton.onClick.AddListener(() => OnChangeValueButton(ADD_INCREMENT, _health));
            _minusHealthButton.onClick.AddListener(() => OnChangeValueButton(MINUS_INCREMENT, _health));

            _addPowerButton.onClick.AddListener(() => OnChangeValueButton(ADD_INCREMENT, _power));
            _minusPowerButton.onClick.AddListener(() => OnChangeValueButton(MINUS_INCREMENT, _power));

            _fightButton.onClick.AddListener(Fight);
        }

        private void InitializeView()
        {
            OnChangeValueButton(_startMoney, _money);
            OnChangeValueButton(_startHealth, _health);
            OnChangeValueButton(_startPower, _power);
        }

        private void OnChangeValueButton(int increment, PlayerData playerData)
        {
            playerData.Value += increment;

            switch (playerData.DataType)
            {
                case DataType.Money:
                    ChangeDataWindow(_countMoneyText, playerData.Value, MONEY_TEXT);
                    break;
                case DataType.Health:
                    ChangeDataWindow(_countHealthText, playerData.Value, HEALTH_TEXT);
                    break;
                case DataType.Power:
                    ChangeDataWindow(_countPowerText, playerData.Value, POWER_TEXT);
                    break;
            }
        }

        private void ChangeDataWindow(TMP_Text text, int data, string aditionalText)
        {
            text.text = $"{aditionalText}{data}";
            _countPowerEnemyText.text = $"Enemy Power {_enemy.CalcPower()}";
        }

        private void Fight()
        {
            bool isWin = _power.Value >= _enemy.CalcPower();
            string message = isWin ? "Win!!!" : "Lose!!!";
            string color = isWin ? "#07FF00" : "#FF0000";

            Debug.Log($"<color={color}>{message}</color>");
        }

        private void Unsubscribe()
        {
            _addMoneyButton.onClick.RemoveAllListeners();
            _minusMoneyButton.onClick.RemoveAllListeners();

            _addHealthButton.onClick.RemoveAllListeners();
            _minusHealthButton.onClick.RemoveAllListeners();

            _addPowerButton.onClick.RemoveAllListeners();
            _minusPowerButton.onClick.RemoveAllListeners();

            _fightButton.onClick.RemoveAllListeners();
        }

        private void OnDestroy()
        {
            Unsubscribe();
            _money.Detach(_enemy);
            _health.Detach(_enemy);
            _power.Detach(_enemy);
        }
    }
}
