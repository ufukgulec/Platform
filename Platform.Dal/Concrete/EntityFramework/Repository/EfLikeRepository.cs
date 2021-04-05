using Platform.Dal.Abstract;
using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Dal.Concrete.EntityFramework.Repository
{
    public class EfLikeRepository : EfGenericRepository<Like>, ILikeRepository
    {
        public EfLikeRepository() : base()
        {

        }
    }
}
