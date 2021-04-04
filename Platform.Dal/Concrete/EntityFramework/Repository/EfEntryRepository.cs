using Platform.Dal.Abstract;
using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Dal.Concrete.EntityFramework.Repository
{
    /// <summary>
    /// Entry için oluşturulmuş repositorydir. Kalıtım aldığı sınıf => EfGenericRepository Kullandığı arabirim => IEntryRepository
    /// </summary>
    public class EfEntryRepository : EfGenericRepository<Entry>, IEntryRepository
    {
        public EfEntryRepository() : base()
        {

        }
        /// <summary>
        /// IsValid değeri(Tag.isValid, Entry.isValid, Person.isValid) TRUE olan Entry listesini döner.
        /// </summary>
        /// <returns>Entries</returns>
        public List<Entry> ActiveEntryGetAll()
        {
            return _context.Entries.Where(x => x.IsValid == true && x.Tag.IsValid == true && x.Person.IsValid == true).ToList();
        }
        /// <summary>
        /// IsValid değeri(Tag.isValid, Entry.isValid, Person.isValid) TRUE olan ve koşula göre Entry listesini döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.EntryID>0</param>
        /// <returns>Entries</returns>
        public List<Entry> ActiveEntryGetAll(Expression<Func<Entry, bool>> expression)
        {
            return ActiveEntryGetAll().AsQueryable().Where(expression).ToList();
        }
        /// <summary>
        /// Eskiden yeniye Entry listesini döner.
        /// </summary>
        /// <returns>Entries</returns>
        public List<Entry> OldToNewEntryGetAll()
        {
            return ActiveEntryGetAll().OrderBy(x => x.EntryDate).ToList();
        }
        /// <summary>
        /// Belli bir tarihteki Entry listesini döner.
        /// </summary>
        /// <returns>Entries</returns>
        public List<Entry> PastHistoryEntryGetAll(DateTime dateTime)
        {
            return ActiveEntryGetAll().Where(x => x.EntryDate.Equals(dateTime)).ToList();
        }
        /// <summary>
        /// Bugünkü Entry Listesi
        /// </summary>
        /// <returns>Entries</returns>
        public List<Entry> TodayEntryGetAll()
        {
            return ActiveEntryGetAll().Where(x => x.EntryDate.Equals(DateTime.Now)).ToList();
        }
        /// <summary>
        /// isValid Değeri TRUE olan entry listesindeki veri adeti
        /// </summary>
        /// <returns>0,1,2,3,4...</returns>
        public int ActiveEntryCount()
        {
            return ActiveEntryGetAll().Count();
        }
     
    }
}
