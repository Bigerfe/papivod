using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Caching;
using System.Web;
 
namespace Linda.DAL
{

    /// <summary>
    /// 缓存数据
    /// </summary>
    public class DoCache
    {
        /// <summary>
        /// 将对象放入缓存
        /// </summary>
        /// <param name="cachekey"></param>
        /// <param name="obj"></param>
        public static void AddCache(string cachekey, object obj)
        {

            if (Global.UseCache)
            {
                if (obj != null && DoCache.GetCache(cachekey)==null)
                {
                    Cache c = HttpRuntime.Cache;
                    c.Insert(cachekey, obj, null, DateTime.Now.AddMinutes(ConfigHelper.GetConfigInt("CacheTime")), Cache.NoSlidingExpiration);
                }
            }
        }

        /// <summary>
        /// 返回缓存数据 
        /// </summary>
        /// <param name="cachekey"></param>
        /// <returns></returns>
        public static object GetCache(string cachekey)
        {
            if (Global.UseCache)
            {
                Cache c = HttpRuntime.Cache;

                if (c[cachekey] != null)
                    return c[cachekey];
                return null;
            }
            else
                return null;


        }


        /// <summary>
        /// 将对象放入缓存(加入文件)
        /// </summary>
        /// <param name="cachekey"></param>
        /// <param name="obj"></param>
        public static void AddCacheChangeInfo(string cachekey, object obj)
        {
            string filename = HttpContext.Current.Server.MapPath("~/cache/changeinfo/index.txt");
            Cache c = HttpRuntime.Cache;
            c.Insert(cachekey, obj, new CacheDependency(filename), DateTime.Now.AddMinutes(ConfigHelper.GetConfigInt("CacheTime")), Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 返回缓存数据 
        /// </summary>
        /// <param name="cachekey"></param>
        /// <returns></returns>
        public static object GetCacheChangeInfo(string cachekey)
        {
            Cache c = HttpRuntime.Cache;

            if (c[cachekey] != null)
                return c[cachekey];
            return null;

        }



    }


}