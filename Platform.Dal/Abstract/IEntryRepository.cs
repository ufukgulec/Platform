using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Dal.Abstract
{
    /// <summary>
    /// Kullandığı arabirim sınıfı => IGenericRepository
    /// </summary>
    public interface IEntryRepository : IGenericRepository<Entry>
    {
        /// <summary>
        /// Id'ye göre Entry ve bağlı olduğu tabloları(Reply,Like) siler.
        /// </summary>
        /// <param name="id">EntryID</param>
        /// <returns>True/False</returns>
        bool Delete(int id);
        /// <summary>
        /// Gelen varlığını siler.
        /// </summary>
        /// <param name="entity">Entry</param>
        /// <returns>True/False</returns>
        bool Delete(Entry entry);
    }
}
