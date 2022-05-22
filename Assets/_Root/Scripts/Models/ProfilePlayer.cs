namespace NikolayTrofimov_MobileGame
{
    internal sealed class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> GameState;
        public readonly Car Car;
        public readonly Transport Transport;
        public readonly InventoryModel InventoryModel;

        public ProfilePlayer(float speed, Transport transport)
        {
            Car = new Car(speed);
            GameState = new SubscriptionProperty<GameState>();
            Transport = transport;
            InventoryModel = new InventoryModel();
        }
    }
}
