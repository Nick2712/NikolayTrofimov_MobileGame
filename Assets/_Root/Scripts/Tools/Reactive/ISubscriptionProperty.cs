using System;


namespace NikolayTrofimov_MobileGame
{
    internal interface ISubscriptionProperty<T>
    {
        T Value { get; }
        void Subscribe(Action<T> action);
        void Unsubscribe(Action<T> action);
    }
}
