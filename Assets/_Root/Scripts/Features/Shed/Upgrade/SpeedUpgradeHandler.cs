namespace NikolayTrofimov_MobileGame
{
    internal sealed class SpeedUpgradeHandler : IUpgradeHandler
    {
        private readonly float _speed;

        public SpeedUpgradeHandler(float speed)
        {
            _speed = speed;
        }

        public void Upgrade(IUpgradable upgradable)
        {
            upgradable.Speed += _speed;
        }
    }
}
