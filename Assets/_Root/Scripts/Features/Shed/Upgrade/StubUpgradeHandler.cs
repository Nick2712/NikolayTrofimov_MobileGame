namespace NikolayTrofimov_MobileGame
{
    internal sealed class StubUpgradeHandler : IUpgradeHandler
    {
        public static readonly IUpgradeHandler Default = new StubUpgradeHandler();

        public void Upgrade(IUpgradable upgradable) { }
    }
}
