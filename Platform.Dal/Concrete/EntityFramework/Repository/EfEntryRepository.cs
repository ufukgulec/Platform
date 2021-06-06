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
        public List<Entry> EntryList()
        {
            return GetAll().Include(x => x.Tag).ToList();
        }

        public List<Entry> EntryList(Expression<Func<Entry, bool>> expression)
        {
            return GetAll(expression).Include(x => x.Tag).ToList();
        }
    }
}