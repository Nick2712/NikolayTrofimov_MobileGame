using System.Collections.Generic;


namespace NikolayTrofimov_MobileGame
{
    internal abstract class Repository<TKey, TValue, TConfig> : IRepository
    {
        private readonly Dictionary<TKey, TValue> _items;
        public IReadOnlyDictionary<TKey, TValue> Items => _items;

        private bool _isDisposed;

        public Repository(IEnumerable<TConfig> configs)
        {
            _items = CreateItems(configs);
        }

        private Dictionary<TKey, TValue> CreateItems(IEnumerable<TConfig> configs)
        {
            var items = new Dictionary<TKey, TValue>();
            foreach (var config in configs)
                items[GetKey(config)] = CreateItem(config);
            return items;
        }

        protected abstract TKey GetKey(TConfig config);
        protected abstract TValue CreateItem(TConfig config);

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _items.Clear();
                _isDisposed = true;
            }
        }
    }
}
