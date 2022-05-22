using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal class ItemsRepository : Repository<string, ItemConfig, ItemConfig>
    {
        public ItemsRepository(IEnumerable<ItemConfig> configs) : base(configs)
        {

        }
        protected override string GetKey(ItemConfig config) => config.Id;

        protected override ItemConfig CreateItem(ItemConfig config) => config;
    }
}
