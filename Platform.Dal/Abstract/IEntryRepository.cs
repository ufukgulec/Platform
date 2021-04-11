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
        /// IsValid değeri(Tag.isValid, Entry.isValid, Person.isValid) TRUE olan Entry listesini döner.
        /// </summary>
        /// <returns>Entries</returns>
        List<Entry> EntryList();
        /// <summary>
        /// IsValid değeri(Tag.isValid, Entry.isValid, Person.isValid) TRUE olan ve koşula göre Entry listesini döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.EntryID>0</param>
        /// <returns>Entries</returns>
        List<Entry> EntryList(Expression<Func<Entry, bool>> expression);

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
