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
    public class LikeManager : GenericManager<Like>, ILikeService
    {
        ILikeRepository _likeRepository;

        public LikeManager(ILikeRepository likeRepository) : base(likeRepository)
        {
            _likeRepository = likeRepository;
        }
    }
}
