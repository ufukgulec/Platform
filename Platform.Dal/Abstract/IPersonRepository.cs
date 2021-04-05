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
    public interface IPersonRepository : IGenericRepository<Person>
    {
        /// <summary>
        /// IsValid değeri TRUE olan Person listesini döner.
        /// </summary>
        /// <returns>People</returns>
        List<Person> ActivePersonGetAll();
        /// <summary>
        /// IsValid değeri TRUE olan ve koşula göre Person listesini döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.PersonID>0</param>
        /// <returns>People</returns>
        List<Person> ActivePersonGetAll(Expression<Func<Person, bool>> expression);
        /// <summary>
        /// Id'ye göre Entry ve bağlı olduğu tabloları(Reply,Like,Entry) siler.
        /// </summary>
        /// <param name="id">PersonID</param>
        /// <returns>True/False</returns>
        bool Delete(int id);
        /// <summary>
        /// Gelen varlığı siler.
        /// </summary>
        /// <param name="person">Person</param>
        /// <returns>True/False</returns>
        bool Delete(Person person);
    }
}
