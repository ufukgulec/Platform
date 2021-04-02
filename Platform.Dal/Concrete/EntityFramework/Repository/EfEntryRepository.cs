using Platform.Dal.Abstract;
using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// IsValid değeri TRUE olan Entry listesini döner.
        /// </summary>
        /// <returns></returns>
        public List<Entry> ActiveEntryGetAll()
        {
            return _context.Entries.Where(x => x.IsValid == true).ToList();
        }
        /// <summary>
        /// Eskiden Yeniye Entry listesini döner.
        /// </summary>
        /// <returns>List<Entry></returns>
        public List<Entry> OldToNewEntryGetAll()
        {
            return _context.Entries.OrderBy(x => x.EntryDate).ToList();
        }
        /// <summary>
        /// Belli bir tarihteki Entry listesini döner.
        /// </summary>
        /// <returns>List<Entry></returns>
        public List<Entry> PastHistoryEntryGetAll(DateTime dateTime)
        {
            return _context.Entries.Where(x => x.EntryDate == dateTime).ToList();
        }
        /// <summary>
        /// Bugünkü Entry Listesi
        /// </summary>
        /// <returns>List<Entry></returns>
        public List<Entry> TodayEntryGetAll()
        {
            return _context.Entries.Where(x => x.EntryDate == DateTime.Now).ToList();
        }
    }
}
