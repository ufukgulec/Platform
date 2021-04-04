using Platform.Dal.Abstract;
using Platform.Entities.Models;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Business
{
    /// <summary>
    /// Personların veritabanı iletişim sınıfıdır. Kalıtım aldığı sınıf => GenericManager Kullandığı arabirim => IPersonService
    /// </summary>
    public class PersonManager : GenericManager<Person>, IPersonService
    {
        IPersonRepository _personRepository;

        public PersonManager(IPersonRepository personRepository) : base(personRepository)
        {
            _personRepository = personRepository;
        }
        /// <summary>
        /// Id'ye göre Entry ve bağlı olduğu tabloları(Reply,Like,Entry) siler.
        /// </summary>
        /// <param name="id">PersonID</param>
        /// <returns>True/False</returns>
        public bool Delete(int id)
        {
            return _personRepository.Delete(id);
        }
        /// <summary>
        /// Gelen varlığı siler.
        /// </summary>
        /// <param name="person">Person</param>
        /// <returns>True/False</returns>
        public bool Delete(Person person)
        {
            return _personRepository.Delete(person);
        }
    }
}
