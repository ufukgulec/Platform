using Platform.Dal.Abstract;
using Platform.Entities.Models;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Dal.Concrete.EntityFramework.Repository
{
    public class EfTagRepository : EfGenericRepository<Tag>, ITagRepository
    {
        public EfTagRepository():base()
        {
                
        }
        public bool Delete(int id)
        {
            return Delete(Get(id));
        }

        public bool Delete(Tag tag)
        {
            _context.Tags.Remove(tag);
            return _context.SaveChanges() > 0;
        }
    }
}
