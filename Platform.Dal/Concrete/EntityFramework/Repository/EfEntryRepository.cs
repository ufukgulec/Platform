using Platform.Dal.Abstract;
using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public List<Entry> EntryList()
        {
            List<Entry> list = _context.Entries
                .Include(x => x.Tag)
                .Include(x => x.Person)
                .Include(x => x.Likes)
                .Where(x => x.IsValid == true && x.Person.IsValid == true && x.Tag.IsValid == true)
                .OrderByDescending(x => x.EntryID)
                .AsNoTracking()
                .ToList();

            return list;
        }
        /// <summary>
        /// IsValid değeri(Tag.isValid, Entry.isValid, Person.isValid) TRUE olan ve koşula göre Entry listesini döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.EntryID>0</param>
        /// <returns>Entries</returns>
        public List<Entry> EntryList(Expression<Func<Entry, bool>> expression)
        {
            return EntryList().AsQueryable().Where(expression).ToList();
        }

        /// <summary>
        /// Id'ye göre Entry ve bağlı olduğu tabloları(Reply,Like) siler.
        /// </summary>
        /// <param name="id">EntryID</param>
        /// <returns>True/False</returns>
        public bool Delete(int id)
        {
            return Delete(Get(id));
        }
        /// <summary>
        /// Gelen varlığı siler.
        /// </summary>
        /// <param name="entity">Entry</param>
        /// <returns>True/False</returns>
        public bool Delete(Entry entry)
        {
            _context.Replies.RemoveRange(_context.Replies.Where(x => x.EntryID == entry.EntryID).ToList());//Entry-Reply
            _context.Likes.RemoveRange(_context.Likes.Where(x => x.EntryID == entry.EntryID).ToList());//Entry-Like
            _context.Entries.Remove(entry);
            return _context.SaveChanges() > 0;
        }
    }
}
