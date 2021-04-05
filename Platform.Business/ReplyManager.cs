using Platform.Dal.Abstract;
using Platform.Entities.Models;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Business
{
    public class ReplyManager : GenericManager<Reply>, IReplyService
    {
        IReplyRepository _replyRepository;

        public ReplyManager(IReplyRepository replyRepository) : base(replyRepository)
        {
            _replyRepository = replyRepository;
        }

        public List<Reply> ActiveReplyGetAll()
        {
            return _replyRepository.ActiveReplyGetAll();
        }

        public List<Reply> ActiveReplyGetAll(Expression<Func<Reply, bool>> expression)
        {
            return _replyRepository.ActiveReplyGetAll(expression);
        }

        public List<Reply> TodayReplyGetAll()
        {
            return _replyRepository.TodayReplyGetAll();
        }
    }
}
