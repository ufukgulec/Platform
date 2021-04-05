using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Cache
{
    public abstract class CacheProvider
    {
        public static int CacheDuration = 60;
        public static CacheProvider Instance;//Static bellekte bir yer kaplamasını sağlayacak.
        /// <summary>
        /// Belleğe değer atama
        /// </summary>
        /// <param name="Key">Anahtar</param>
        /// <param name="Value">Obje</param>
        public abstract void Set(string Key, object Value);
        /// <summary>
        /// Bellekten getirme
        /// </summary>
        /// <param name="Key">Anahtar</param>
        /// <returns></returns>
        public abstract object Get(string Key);
        /// <summary>
        /// Bellekten veri seti silme
        /// </summary>
        /// <param name="Key">Anahtar</param>
        public abstract void Remove(string Key);
        /// <summary>
        /// Bellekte olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="Key">Anahtar</param>
        /// <returns></returns>
        public abstract bool IsExist(string Key);
    }
}
