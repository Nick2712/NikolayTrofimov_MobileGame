using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NikolayTrofimov_MobileGame_Lesson5
{
    internal abstract class DataPlayer
    {
        private string _titleData;
        private int _countMoney;
        private int _countHealth;
        private int _countPower;

        private List<IEnemy> _enemies = new List<IEnemy>();

        public string TitleData => _titleData;

        public int Money
        {
            get => _countMoney;
            set => SetValue(ref _countMoney, value, DataType.Money);
        }
        public int Health
        {
            get => _countHealth;
            set => SetValue(ref _countHealth, value, DataType.Health);
        }
        public int Power
        {
            get => _countPower;
            set => SetValue(ref _countPower, value, DataType.Power);
        }


        public DataPlayer(string titleData)
        {
            _titleData = titleData;
        }

        private void SetValue(ref int targetValue, int value, DataType dataType)
        {
            if (targetValue != value)
            {
                targetValue = value;
                Notify(dataType);
            }
        }

        public void Attach(IEnemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void Detach(IEnemy enemy)
        {
            _enemies.Remove(enemy);
        }

        protected void Notify(DataType dataType)
        {
            foreach(var investor in _enemies)
            {
                investor.Update(this, dataType);
            }
        }
    }
}
