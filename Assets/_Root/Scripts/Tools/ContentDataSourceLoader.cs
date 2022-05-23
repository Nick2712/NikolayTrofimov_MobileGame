using System;
using System.Linq;


namespace NikolayTrofimov_MobileGame
{
    internal class ContentDataSourceLoader
    {
        public static ItemConfig[] LoadItemConfigs(string path)
        {
            var dataSource = ResourceLoader.LoadResource<ItemConfigDataSource>(path);
            return dataSource == null ? Array.Empty<ItemConfig>() : dataSource.ItemConfigs.ToArray();
        }

        public static UpgradeItemConfig[] LoadUpgradeItemConfigs(string path)
        {
            var dataSource = ResourceLoader.LoadResource<UpgradeItemConfigDataSource>(path);
            return dataSource == null ? Array.Empty<UpgradeItemConfig>() : dataSource.ItemConfigs.ToArray();
        }
    }
}
