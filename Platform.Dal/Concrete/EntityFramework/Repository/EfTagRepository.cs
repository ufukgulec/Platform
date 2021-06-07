using Platform.Dal.Abstract;
using Platform.Entities.Models;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Dal.Concrete.EntityFramework.Repository
{
    public class EfTagRepository : EfGenericRepository<Tag>, ITagRepository
    {
        public EfTagRepository() : base()
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

        public List<Tag> List()
        {
            var list = GetAll().OrderByDescending(x => x.Entries.Count).ToList();
            return list;
        }

        public List<Tag> List(Expression<Func<Tag, bool>> expression)
        {
            var list = GetAll().OrderByDescending(x => x.Entries.Count).Where(expression).ToList();
            return list;
        }
    }
}
