using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal class UpgradeHandlersRepository : Repository<string, IUpgradeHandler, IUpgradeItem>
    {
        public UpgradeHandlersRepository(IEnumerable<IUpgradeItem> configs) : base(configs)
        {
        }

        protected override string GetKey(IUpgradeItem config)
        {
            return config.Id;
        }

        protected override IUpgradeHandler CreateItem(IUpgradeItem config)
        {
            return config.Type switch
            {
                UpgradeType.Speed => new SpeedUpgradeHandler(config.Value),
                UpgradeType.JumpHeight => new JumpHeightUpgradeHandler(config.Value),
                _ => StubUpgradeHandler.Default
            };
        }
    }
}
