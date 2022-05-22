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
    }
}
