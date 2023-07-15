namespace Api.Snack.Services
{
    public class CacheObject
    {
        public CacheObject(object obj, DateTime expiryTime)
        {
            ExpiryTime = expiryTime.ToUniversalTime();
            Object = obj;
        }

        public CacheObject(object obj)
        {
            ExpiryTime = DateTime.UtcNow.AddDays(1);
            Object = obj;
        }

        public DateTime ExpiryTime { get; set; }
        public object Object { get; set; }
    }

    public class CacheService
    {
        private Dictionary<string, CacheObject> Cache { get; set; }
        public CacheService()
        {
            Cache = new Dictionary<string, CacheObject>();
        }

        public void SetCacheKey(string key, object cacheValue)
        {
            // add with date time

            var value = new CacheObject(cacheValue);

            value.Object = cacheValue;

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
            if (!Cache.TryGetValue(key, out CacheObject? value))
            {
                cache = default;
                return false;
            }

            if (value.Object is not T)
            {
                cache = default;
                return false;
            }

            cache = (T)value.Object;
            return true;
        }
    }
}