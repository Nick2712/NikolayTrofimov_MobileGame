using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson5
{
    internal sealed class Enemy : IEnemy
    {
        private const int KMONEY = 5;
        private const float KPOWER = 1.5f;
        private const int MAX_HEALTH_PLAYER = 20;

        private readonly string _name;
        private int _moneyPlayer;
        private int _healthPlayer;
        private int _powerPlayer;

        public int Power
        {
            get
            {
                var kHealth = _healthPlayer > MAX_HEALTH_PLAYER ? 100 : 5;
                var power = (int)(_moneyPlayer / KMONEY + kHealth + _powerPlayer / KPOWER);

                return power;
            }
        }


        public Enemy(string name)
        {
            _name = name;
        }

        public void Update(DataPlayer dataPlayer, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Money:
                    _moneyPlayer = dataPlayer.Money;
                    break;
                case DataType.Health:
                    _healthPlayer = dataPlayer.Health;
                    break;
                case DataType.Power:
                    _powerPlayer = dataPlayer.Power;
                    break;
            }

            Debug.Log($"Notified {_name} change to {dataPlayer}");
        }
    }
}
