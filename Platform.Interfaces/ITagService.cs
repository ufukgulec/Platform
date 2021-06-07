using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Interfaces
{
    public interface ITagService : IGenericService<Tag>
    {
        /// <summary>
        /// Tag List
        /// </summary>
        /// <returns>Tags</returns>
        List<Tag> List();
        /// <summary>
        /// IsValid değeri(Tag.isValid) TRUE olan ve koşula göre Tag listesini döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.TagID>0</param>
        /// <returns>Tags</returns>
        List<Tag> List(Expression<Func<Tag, bool>> expression);
        /// <summary>
        /// Id'ye göre Tag ve bağlı olduğu tabloları(Reply,Like) siler.
        /// </summary>
        /// <param name="id">TagID</param>
        /// <returns>True/False</returns>
        bool Delete(int id);
        /// <summary>
        /// Gelen varlığı siler.
        /// </summary>
        /// <param name="tags">Tag</param>
        /// <returns>True/False</returns>
        bool Delete(Tag tag);
        /// <summary>
        /// Popular Tag List
        /// </summary>
        /// <param name="value">Kaç tane çekmek istiyorsun</param>
        /// <returns></returns>
        List<Tag> PopularTags();

    }
}
