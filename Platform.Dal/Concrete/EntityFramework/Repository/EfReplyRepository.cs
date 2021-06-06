using Platform.Dal.Abstract;
using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Dal.Concrete.EntityFramework.Repository
{
    public class EfReplyRepository : EfGenericRepository<Reply>, IReplyRepository
    {
        public EfReplyRepository() : base()
        {

        }
        /// <summary>
        /// IsValid değeri TRUE olan Reply listesini döner.
        /// </summary>
        /// <returns>Replies</returns>
        public List<Reply> List()
        {
            return _context.Replies.Where(x => x.IsValid == true && x.Entry.IsValid == true && x.Person.IsValid == true).ToList();
        }
        /// <summary>
        /// IsValid değeri TRUE olan ve koşula göre Reply listesini döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.ReplyID>0</param>
        /// <returns>Replies</returns>
        public List<Reply> List(Expression<Func<Reply, bool>> expression)
        {
            return List().AsQueryable().Where(expression).ToList();
        }
        /// <summary>
        /// Bugünkü Reply Listesi
        /// </summary>
        /// <returns>Replies</returns>
        public List<Reply> TodayReplyGetAll()
        {
            return List().Where(x => x.ReplyDate.Equals(DateTime.Now)).ToList();
        }
    }
}
