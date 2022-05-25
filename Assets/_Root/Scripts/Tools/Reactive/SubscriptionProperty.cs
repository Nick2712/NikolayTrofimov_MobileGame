using System;


namespace NikolayTrofimov_MobileGame
{
    internal sealed class SubscriptionProperty<T> : ISubscriptionProperty<T>
    {
        private Action<T> _action;
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                _action?.Invoke(_value);
            }
        }

        public void Subscribe(Action<T> action)
        {
            _action += action;
        }

        public void Unsubscribe(Action<T> action)
        {
            _action -= action;
        }
    }
}
