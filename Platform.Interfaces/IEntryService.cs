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
        /// EntryID'ye göre azalan sıralanmış Entry Listesi döner.
        /// </summary>
        /// <returns>Entry List</returns>
        List<Entry> List();
        /// <summary>
        /// EntryID'ye göre azalan sıralanmış ve koşula göre Entry Listesi döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.EntryID>0</param>
        /// <returns>Entry List</returns>
        List<Entry> List(Expression<Func<Entry, bool>> expression);
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
        /// <summary>
        /// Entrytitle, EntryArticle, PersonID ve TagID olarak gelen varlığı Generic Add metoduna yönlendirir.
        /// </summary>
        /// <param name="entry">Entry</param>
        /// <returns>Entry</returns>
        Entry Post(Entry entry);
        /// <summary>
        /// Datetime.Now.Date e eşit olan (Bugun) Entry listesi
        /// </summary>
        /// <returns>Entries</returns>
        List<Entry> TodayEntries();
        /// <summary>
        /// EntryID'ye ve Entry.Like.Count'a göre azalan sıralanmış Entry Listesi döner.
        /// </summary>
        /// <param name="value">Kaç tane çekmek istiyorsun ?</param>
        /// <returns>Entry List</returns>
        List<Entry> PopularEntries(int a);

    }
}
