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
    /// Person için oluşturulmuş repositorydir. Kalıtım aldığı sınıf => EfGenericRepository Kullandığı arabirim => IPersonRepository
    /// </summary>
    public class EfPersonRepository : EfGenericRepository<Person>, IPersonRepository
    {
        public EfPersonRepository() : base()
        {

        }
        /// <summary>
        /// IsValid değeri TRUE olan Person listesini döner.
        /// </summary>
        /// <returns>People</returns>
        public List<Person> List()
        {
            return _context.People.Where(x => x.IsValid == true).ToList();
        }
        /// <summary>
        /// IsValid değeri TRUE olan ve koşula göre Person listesini döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.PersonID>0</param>
        /// <returns>People</returns>
        public List<Person> List(Expression<Func<Person, bool>> expression)
        {
            return List().AsQueryable().Where(expression).ToList();
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

        public Person Login(string Username, string password)
        {
            return _context.People.Where(x => x.Username == Username && x.Password == password).SingleOrDefault();
        }
    }
}
