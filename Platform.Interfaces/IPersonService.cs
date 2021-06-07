using Platform.Entities.Models;
using Platform.Entities.PocoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Interfaces
{
    /// <summary>
    /// Kullandığı inteface => IGenericService
    /// </summary>
    public interface IPersonService : IGenericService<Person>
    {
        /// <summary>
        /// IsValid değeri TRUE olan Person listesini döner.
        /// </summary>
        /// <returns>People</returns>
        List<Person> List();
        /// <summary>
        /// IsValid değeri TRUE olan ve koşula göre Person listesini döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.PersonID>0</param>
        /// <returns>People</returns>
        List<Person> List(Expression<Func<Person, bool>> expression);
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
        /// <summary>
        /// Kullanıcı Giriş metodu
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="parola"></param>
        /// <returns></returns>
        PocoPerson Login(string Username, string password);
        Person Register(Person person);
        /// <summary>
        /// İsme göre kullanıcı bulur.
        /// </summary>
        /// <param name="username">PersonName</param>
        /// <returns>Person</returns>
        Person FindByName(string username);
    }
}
