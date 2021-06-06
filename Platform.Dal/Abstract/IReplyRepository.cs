using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Dal.Abstract
{
    public interface IReplyRepository:IGenericRepository<Reply>
    {
        /// <summary>
        /// IsValid değeri TRUE olan Reply listesini döner.
        /// </summary>
        /// <returns>Replies</returns>
        List<Reply> List();
        /// <summary>
        /// IsValid değeri TRUE olan ve koşula göre Reply listesini döner.
        /// </summary>
        /// <param name="expression">Koşul x=>x.ReplyID>0</param>
        /// <returns>Replies</returns>
        List<Reply> List(Expression<Func<Reply, bool>> expression);
        /// <summary>
        /// Bugünkü Reply Listesi
        /// </summary>
        /// <returns>Replies</returns>
        List<Reply> TodayReplyGetAll();
    }
}
