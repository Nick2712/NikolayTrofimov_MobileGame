using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class PlayerData
    {
        private int _value;
        
        private readonly List<IEnemy> _enemies = new List<IEnemy>();

        public DataType DataType { get; }

        public int Value
        {
            get => _value;
            set => SetValue(ref _value, value);
        }
        

        public PlayerData(DataType dataType)
        {
            DataType = dataType;
        }

        private void SetValue(ref int refValue, int value)
        {
            if (refValue != value)
            {
                refValue = value;
                Notify();
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

        private void Notify()
        {
            foreach(var investor in _enemies)
            {
                investor.Update(this);
            }
        }
    }
}
