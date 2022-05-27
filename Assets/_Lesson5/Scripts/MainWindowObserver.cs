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

        [SerializeField] private TMP_Text _countMoneyText;
        [SerializeField] private TMP_Text _countHealthText;
        [SerializeField] private TMP_Text _countPowerText;
        [SerializeField] private TMP_Text _countPowerEnemyText;

        [SerializeField] private Button _addCoinsButton;
        [SerializeField] private Button _minusCoinsButton;

        [SerializeField] private Button _addHealthButton;
        [SerializeField] private Button _minusHealthButton;

        [SerializeField] private Button _addPowerButton;
        [SerializeField] private Button _minusPowerButton;

        [SerializeField] private Button _fightButton;

        private int _allCountMoneyPlayer;
        private int _allCountHealthPlayer;
        private int _allCountPowerPlayer;

        private Money _money;
        private Health _health;
        private Power _power;

        private Enemy _enemy;


        private void Start()
        {
            _enemy = new Enemy("Enemy Flappy");

            _money = new Money(nameof(Money));
            _health = new Health(nameof(Health));
            _power = new Power(nameof(Power));
            _money.Attach(_enemy);
            _health.Attach(_enemy);
            _power.Attach(_enemy);

            _addCoinsButton.onClick.AddListener(() => OnChangeValueButton(ADD_INCREMENT, DataType.Money));
            _minusCoinsButton.onClick.AddListener(() => OnChangeValueButton(MINUS_INCREMENT, DataType.Money));

            _addHealthButton.onClick.AddListener(() => OnChangeValueButton(ADD_INCREMENT, DataType.Health));
            _minusHealthButton.onClick.AddListener(() => OnChangeValueButton(MINUS_INCREMENT, DataType.Health));

            _addPowerButton.onClick.AddListener(() => OnChangeValueButton(ADD_INCREMENT, DataType.Power));
            _minusPowerButton.onClick.AddListener(() => OnChangeValueButton(MINUS_INCREMENT, DataType.Power));

            _fightButton.onClick.AddListener(Fight);

            InitializeView();
        }

        private void InitializeView()
        {
            OnChangeValueButton(0, DataType.Money);
            OnChangeValueButton(0, DataType.Health);
            OnChangeValueButton(0, DataType.Power);
        }

        private void OnChangeValueButton(int increment, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Money:
                    ChangeData(ref _allCountMoneyPlayer, increment);
                    _money.Money = _allCountMoneyPlayer;
                    ChangeDataWindow(_countMoneyText, _allCountMoneyPlayer, MONEY_TEXT);
                    break;
                case DataType.Health:
                    ChangeData(ref _allCountHealthPlayer, increment);
                    _health.Health = _allCountHealthPlayer;
                    ChangeDataWindow(_countHealthText, _allCountHealthPlayer, HEALTH_TEXT);
                    break;
                case DataType.Power:
                    ChangeData(ref _allCountPowerPlayer, increment);
                    _power.Power = _allCountPowerPlayer;
                    ChangeDataWindow(_countPowerText, _allCountPowerPlayer, POWER_TEXT);
                    break;
            }
        }

        private void ChangeData(ref int targetValue, int increment)
        {
            targetValue += increment;
        }

        private void ChangeDataWindow(TMP_Text text, int data, string aditionalText)
        {
            text.text = $"{aditionalText}{data}";
            _countPowerEnemyText.text = $"Enemy Power {_enemy.Power}";
        }

        private void Fight()
        {
            Debug.Log(_allCountPowerPlayer >= _enemy.Power
                ? "<color=#07FF00>Win!!!</color>"
                : "<color=#FF0000>Lose!!!</color>");
        }
    }
}
