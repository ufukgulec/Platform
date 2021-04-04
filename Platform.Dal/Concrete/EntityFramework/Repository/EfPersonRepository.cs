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
    /// Person için oluşturulmuş repositorydir. Kalıtım aldığı sınıf => EfGenericRepository Kullandığı arabirim => IPersonRepository
    /// </summary>
    public class EfPersonRepository : EfGenericRepository<Person>, IPersonRepository
    {
        public EfPersonRepository() : base()
        {

        }
        /// <summary>
        /// Id'ye göre Entry ve bağlı olduğu tabloları(Reply,Like,Entry) siler.
        /// </summary>
        /// <param name="id">PersonID</param>
        /// <returns>True/False</returns>
        public bool Delete(int id)
        {
            return Delete(Get(id));
        }
        /// <summary>
        /// Gelen varlığı siler.
        /// </summary>
        /// <param name="person">Person</param>
        /// <returns>True/False</returns>
        public bool Delete(Person person)
        {
            _context.Replies.RemoveRange(_context.Replies.Where(x => x.PersonID == person.PersonID).ToList());//Entry-Reply
            _context.Likes.RemoveRange(_context.Likes.Where(x => x.PersonID == person.PersonID).ToList());//Entry-Like
            _context.Entries.RemoveRange(_context.Entries.Where(x => x.PersonID == person.PersonID).ToList());//Entry-Entry
            _context.People.Remove(person);
            return _context.SaveChanges() > 0;
        }
    }
}
