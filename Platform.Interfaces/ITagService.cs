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
        /// Entry sayısına göre azalan sıralanmış Tag listesi döner.
        /// </summary>
        /// <returns>Tag List</returns>
        List<Tag> List();
        /// <summary>
        /// Entry sayısına göre azalan sıralanmış ve koşula göre Tag listesi döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.TagID>0</param>
        /// <returns>Tag List</returns>
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
        /// Entry sayısına göre azalan sıralanmış ve 5 adet Tag döner.
        /// </summary>
        /// <param name="value">Kaç tane çekmek istiyorsun</param>
        /// <returns>Tag List</returns>
        List<Tag> PopularTags();

    }
}
