namespace Api.Snack.Services
{
    public class CacheService
    {
        private Dictionary<string, object> Cache { get; set; }
        public CacheService()
        {
            Cache = new Dictionary<string, object>();
        }

        public void SetCacheKey(string key, object value)
        {
            Cache[key] = value;
        }

        public void RemoveCacheKey(string key)
        {
            if (Cache.ContainsKey(key))
            {
                Cache.Remove(key);
            }
        }

        public bool TryGetCache<T>(string key, out T? cache)
        {
            if (!Cache.TryGetValue(key, out object? value))
            {
                cache = default;
                return false;
            }

            if (value is not T)
            {
                cache = default;
                return false;
            }

            cache = (T)value;
            return true;
        }
    }
}