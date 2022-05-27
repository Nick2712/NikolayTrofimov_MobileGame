using UnityEngine;


namespace NikolayTrofimov_MobileGame_Lesson5
{
    internal sealed class Enemy : IEnemy
    {
        private const float KMONEY = 5;
        private const float KPOWER = 1.5f;
        private const float KCRIME = 3.0f;
        private const int MAX_HEALTH_PLAYER = 20;

        private readonly string _name;
        private int _moneyPlayer;
        private int _healthPlayer;
        private int _powerPlayer;
        private int _crimePlayer;


        public int CalcPower()
        {
            var kHealth = _healthPlayer > MAX_HEALTH_PLAYER ? 100 : 5;
            var powerRatio = _powerPlayer / KPOWER;
            var moneyRatio = _moneyPlayer / KMONEY;
            var crimeRatio = _crimePlayer / KCRIME;

            return (int)(moneyRatio + kHealth + powerRatio + crimeRatio);
        }

        public Enemy(string name)
        {
            _name = name;
        }

        public void Update(PlayerData playerData)
        {
            switch (playerData.DataType)
            {
                case DataType.Money:
                    _moneyPlayer = playerData.Value;
                    break;
                case DataType.Health:
                    _healthPlayer = playerData.Value;
                    break;
                case DataType.Power:
                    _powerPlayer = playerData.Value;
                    break;
                case DataType.Crime:
                    _crimePlayer = playerData.Value;
                    break;
            }

            Debug.Log($"Notified {_name} change to {playerData.DataType}");
        }
    }
}
