using Platform.Dal.Abstract;
using Platform.Entities.Models;
using Platform.Entities.PocoModels;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        /// IsValid değeri TRUE olan Person listesini döner.
        /// </summary>
        /// <returns>People</returns>
        public List<Person> ActivePersonGetAll()
        {
            return _personRepository.ActivePersonGetAll();
        }
        /// <summary>
        /// IsValid değeri TRUE olan ve koşula göre Person listesini döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.PersonID>0</param>
        /// <returns>People</returns>
        public List<Person> ActivePersonGetAll(Expression<Func<Person, bool>> expression)
        {
            return _personRepository.ActivePersonGetAll(expression);
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

        public PocoPerson Login(string Username, string password)
        {
            if (String.IsNullOrEmpty(Username.Trim()))
            {
                throw new Exception("Kullanıcı Adı boş geçilemez");
            }
            else if (String.IsNullOrEmpty(password.Trim()))
            {
                throw new Exception("Parola boş geçilemez");
            }
            var sifre = new ToPasswordRepository().Md5(password);
            var user = _personRepository.Login(Username, sifre);
            if (user == null)
            {
                throw new Exception("Kullanıcı adınızı veya parolanızı kontrol ediniz.");
            }
            else
            {
                return new PocoPerson()
                {
                    PersonID = user.PersonID,
                    Username = user.Username,
                    PersonTypeID = (int)user.PersonTypeID
                };
            }
        }
        public Person Register(Person person)
        {
            person.Password = new ToPasswordRepository().Md5(person.Password);
            person.IsValid = true;
            person.PersonTypeID = 1;
            return _personRepository.Add(person);
        }
    }
}
