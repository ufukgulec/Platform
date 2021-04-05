using Platform.Cache;
using Platform.Dal.Concrete.EntityFramework.Repository;
using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Business
{
    public class CacheFonksiyon
    {
        DefaultCacheProvider provider = new DefaultCacheProvider();
        /// <summary>
        /// Uygulama başladığında tüm belleği temizler
        /// </summary>
        public void CacheClear()
        {

            provider.Remove(Enums.CacheKey.Tags.ToString());
            provider.Remove(Enums.CacheKey.PersonTypes.ToString());
        }
        public void CacheCreate()
        {
            object tagsCache = null;
            try
            {
                GenericManager<Tag> genericManager = new GenericManager<Tag>(new EfGenericRepository<Tag>());
                var tags = genericManager.GetAll(x => x.IsValid == true);
                if (tags != null)
                {
                    tagsCache = tags;
                }
                else
                    throw new Exception("tagsCache Doldurulamadı.");
            }
            catch (Exception error)
            {
                Trace.WriteLine("Tags cache getirilemedi.");
                throw new Exception("Tags cache getirilemedi.", error);
            }

            provider.Set(Enums.CacheKey.Tags.ToString(), tagsCache);
        }
        public List<Tag> TagsGet()
        {
            List<Tag> value = null;
            try
            {
                var liste = ((List<Tag>)provider.Get(Enums.CacheKey.Tags.ToString()));
                if (liste != null)
                {
                    value = liste;
                }
            }
            catch (Exception err)
            {
                value = null;
                Trace.WriteLine("Tags Cacheden okunamadı" + err.Message);
            }
            return value;
        }

    }
}
