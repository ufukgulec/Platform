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
    public class PersonManager : GenericManager<Person>, IPersonService
    {
        IPersonRepository _personRepository;

        public PersonManager(IPersonRepository personRepository) : base(personRepository)
        {
            _personRepository = personRepository;
        }
    }
}
