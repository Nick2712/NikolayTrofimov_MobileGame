namespace NikolayTrofimov_MobileGame
{
    internal sealed class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> GameState;
        public readonly Car Car;

        public ProfilePlayer(float speed)
        {
            Car = new Car(speed);
            GameState = new SubscriptionProperty<GameState>();
        }
    }
}
