using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
