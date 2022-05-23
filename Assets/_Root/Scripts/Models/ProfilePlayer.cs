namespace NikolayTrofimov_MobileGame
{
    internal sealed class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> GameState;
        public readonly TransportModel Transport;
        public readonly InventoryModel InventoryModel;

        public ProfilePlayer(float speed, Transport transport)
        {
            Transport = new TransportModel(speed, transport);
            GameState = new SubscriptionProperty<GameState>();
            InventoryModel = new InventoryModel();
        }
    }
}
