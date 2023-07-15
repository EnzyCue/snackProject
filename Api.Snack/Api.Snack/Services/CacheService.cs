namespace Api.Snack.Services
{
    public class CacheService
    {
        public Dictionary<string, object> Cache { get; set; }
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

        public T? GetCache<T>(string key)
        {
            if (!Cache.TryGetValue(key, out object? value))
                return default;

            if (value is not T) return default;

            return (T)value;
        }
    }
}