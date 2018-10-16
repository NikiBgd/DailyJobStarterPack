using System;
using System.Collections.Generic;
using System.Runtime.Caching;


namespace DailyJobStarterPack.Web.Caching
{
    public class InMemoryCache : ICacheService
    {
        public void Set<T>(string cacheKey, T item, int durationInMinutes) where T : class
        {
            MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(durationInMinutes));
        }

        public T Get<T>(string cacheKey) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            return item;
        }
    }

    interface ICacheService
    {
        void Set<T>(string cacheKey, T item, int durationInMinutes) where T : class;
        T Get<T>(string cacheKey) where T : class;
    }
}
