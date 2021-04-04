using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Interfaces
{
    /// <summary>
    /// Kullandığı interface => IGenericService
    /// </summary>
    public interface IEntryService : IGenericService<Entry>
    {
        /// <summary>
        /// IsValid değeri(Tag.isValid, Entry.isValid, Person.isValid) TRUE olan Entry listesini döner.
        /// </summary>
        /// <returns>Entries</returns>
        List<Entry> ActiveEntryGetAll();
        /// <summary>
        /// IsValid değeri(Tag.isValid, Entry.isValid, Person.isValid) TRUE olan ve koşula göre Entry listesini döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.EntryID>0</param>
        /// <returns>Entries</returns>
        List<Entry> ActiveEntryGetAll(Expression<Func<Entry, bool>> expression);
        /// <summary>
        /// Bugünkü Entry Listesi
        /// </summary>
        /// <returns>Entries</returns>
        List<Entry> TodayEntryGetAll();
        /// <summary>
        /// Belli bir tarihteki Entry listesini döner.
        /// </summary>
        /// <returns>Entries</returns>
        List<Entry> PastHistoryEntryGetAll(DateTime dateTime);
        /// <summary>
        /// Eskiden yeniye Entry listesini döner.
        /// </summary>
        /// <returns>Entries</returns>
        List<Entry> OldToNewEntryGetAll();
        /// <summary>
        /// isValid Değeri TRUE olan entry listesindeki veri adeti
        /// </summary>
        /// <returns>0,1,2,3,4...</returns>
        int ActiveEntryCount();
        /// <summary>
        /// Id'ye göre Entry ve bağlı olduğu tabloları(Reply,Like) siler.
        /// </summary>
        /// <param name="id">EntryID</param>
        /// <returns>True/False</returns>
        bool Delete(int id);
        /// <summary>
        /// Gelen varlığı siler.
        /// </summary>
        /// <param name="entity">Entry</param>
        /// <returns>True/False</returns>
        bool Delete(Entry entry);

    }
}
