using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Dal.Abstract
{
    public interface ITagRepository:IGenericRepository<Tag>
    {
        /// <summary>
        /// Id'ye göre Tag ve bağlı olduğu tabloları(Reply,Like) siler.
        /// </summary>
        /// <param name="id">TagID</param>
        /// <returns>True/False</returns>
        bool Delete(int id);
        /// <summary>
        /// Gelen varlığını siler.
        /// </summary>
        /// <param name="tag">Tag</param>
        /// <returns>True/False</returns>
        bool Delete(Tag tag);
    }
}
