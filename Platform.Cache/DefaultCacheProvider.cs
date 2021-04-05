using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Cache
{
    public class DefaultCacheProvider : CacheProvider
    {
        ObjectCache _cache;
        CacheItemPolicy _policy;

        public DefaultCacheProvider()
        {
            Trace.WriteLine("Cache Başlatıldı.");//Loglama için
            _cache = MemoryCache.Default;
            _policy = new CacheItemPolicy
            {
                Priority = CacheItemPriority.NotRemovable,//Priority öncelik belirtir. NotRemovable silinmesin anlamında
                //AbsoluteExpiration=DateTime.Now.AddHours(1),//Oluştuktan 1 saat sonra cache yık
                RemovedCallback = new CacheEntryRemovedCallback(RemovedCallback)//Yıkıldığında çalışır
            };
        }
        private void RemovedCallback(CacheEntryRemovedArguments arguments)
        {
            Trace.WriteLine("----------------Cache Yıkıldı!--------------------");

            Trace.WriteLine("Key" + arguments.CacheItem.Key);
            Trace.WriteLine("Value" + arguments.CacheItem.Value);
            Trace.WriteLine("Reason" + arguments.RemovedReason);
        }
        public override object Get(string Key)
        {
            object item;
            try
            {
                item = _cache.Get(Key);
                if (item == null)
                {
                    Trace.WriteLine("Cache Getirilemedi...");
                    throw new Exception("Cache Getirilemedi.");
                }
            }
            catch (Exception error)
            {
                item = null;
                Trace.WriteLine("Cache Get sırasında hata oluştu" + error.Message);
                throw new Exception("Cache Get sırasında hata oluştu.", error);
            }
            return item;
        }

        public override bool IsExist(string Key)
        {
            return _cache.Any(x => x.Key == Key);
        }

        public override void Remove(string Key)
        {
            if (IsExist(Key))
            {
                _cache.Remove(Key);
            }

        }

        public override void Set(string Key, object Value)
        {
            _cache.Set(Key, Value, _policy);
        }
    }
}
