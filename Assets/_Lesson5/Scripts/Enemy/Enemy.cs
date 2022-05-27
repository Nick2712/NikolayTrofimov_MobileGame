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


        public int CalcPower()
        {
            var kHealth = _healthPlayer > MAX_HEALTH_PLAYER ? 100 : 5;
            var powerRatio = _powerPlayer / KPOWER;
            int moneyRatio = _moneyPlayer / KMONEY;

            return (int)(moneyRatio + kHealth + powerRatio);
        }

        public Enemy(string name)
        {
            _name = name;
        }

        public void Update(PlayerData playerData)
        {
            _moneyPlayer = playerData.Value;
            
            Debug.Log($"Notified {_name} change to {playerData.DataType}");
        }
    }
}
