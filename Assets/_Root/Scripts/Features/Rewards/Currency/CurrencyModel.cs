namespace NikolayTrofimov_MobileGame
{
    internal sealed class CurrencyModel
    {
        public readonly SubscriptionProperty<int> Wood;
        public readonly SubscriptionProperty<int> Diamond;


        public CurrencyModel()
        {
            Wood = new SubscriptionProperty<int>();
            Diamond = new SubscriptionProperty<int>();
        }
    }
}
