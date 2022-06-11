namespace NikolayTrofimov_MobileGame
{
    internal sealed class PauseModel
    {
        public readonly SubscriptionProperty<bool> OnPause;

        public PauseModel()
        {
            OnPause = new SubscriptionProperty<bool>();
        }
    }
}
