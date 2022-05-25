using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal class ItemsRepository : Repository<string, IItem, IItem>, IItemsRepository
    {
        public ItemsRepository(IEnumerable<ItemConfig> configs) : base(configs)
        {

        }
        protected override string GetKey(IItem config) => config.Id;

        protected override IItem CreateItem(IItem config) => config;
    }
}
