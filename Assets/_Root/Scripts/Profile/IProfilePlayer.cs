namespace NikolayTrofimov_MobileGame
{
    internal interface IProfilePlayer
    {
        SubscriptionProperty<GameState> GameState { get; }
        TransportModel Transport { get; }
        InventoryModel InventoryModel { get; }
    }
}
