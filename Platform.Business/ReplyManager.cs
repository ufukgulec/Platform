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

        public List<Reply> List()
        {
            return _replyRepository.List();
        }

        public List<Reply> List(Expression<Func<Reply, bool>> expression)
        {
            return _replyRepository.List(expression);
        }

        public List<Reply> TodayReplyGetAll()
        {
            return _replyRepository.TodayReplyGetAll();
        }
    }
}
