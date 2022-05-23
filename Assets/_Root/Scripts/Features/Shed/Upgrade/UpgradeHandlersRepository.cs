using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal class UpgradeHandlersRepository : Repository<string, IUpgradeHandler, UpgradeItemConfig>
    {
        public UpgradeHandlersRepository(IEnumerable<UpgradeItemConfig> configs) : base(configs)
        {
        }

        protected override string GetKey(UpgradeItemConfig config)
        {
            return config.Id;
        }

        protected override IUpgradeHandler CreateItem(UpgradeItemConfig config)
        {
            return config.Type switch
            {
                UpgradeType.Speed => new SpeedUpgradeHandler(config.Value),
                _ => StubUpgradeHandler.Default
            };
        }
    }
}
