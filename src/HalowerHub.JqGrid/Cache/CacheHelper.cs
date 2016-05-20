using System;
using System.Web;
using System.Web.Caching;

namespace HalowerHub.JqGrid
{
    public class CacheHelper
    {
        public static object Get(string cacheKey)
        {
            return HttpRuntime.Cache[cacheKey];
        }

        public static void Add(string cacheKey, object obj, int cacheMinute)
        {
            HttpRuntime.Cache.Insert(cacheKey, obj, null, DateTime.Now.AddMinutes(cacheMinute),
                Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }
    }
}