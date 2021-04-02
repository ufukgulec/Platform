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
    }
}
