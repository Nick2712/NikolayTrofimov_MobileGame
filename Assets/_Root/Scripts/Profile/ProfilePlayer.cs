namespace NikolayTrofimov_MobileGame
{
    internal sealed class ProfilePlayer : IProfilePlayer
    {
        public SubscriptionProperty<GameState> GameState { get; }
        public SubscriptionProperty<Language> Language { get; }
        public TransportModel Transport { get; }
        public InventoryModel InventoryModel { get; }

        public readonly CurrencyModel Currency;
        public readonly PauseModel Pause;


        public ProfilePlayer(float speed, float jumpHeight, Transport transport)
        {
            Transport = new TransportModel(speed, jumpHeight, transport);
            GameState = new SubscriptionProperty<GameState>();
            InventoryModel = new InventoryModel();
            Currency = new CurrencyModel();
            Pause = new PauseModel();
            Language = new SubscriptionProperty<Language>();
            Language.Value = NikolayTrofimov_MobileGame.Language.English;
        }
    }
}
