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

        public Like LikeOrDislike(int EntryID, int PersonID)
        {
            var controlLike = _likeRepository.GetAll().Where(x => x.PersonID == PersonID && x.EntryID == EntryID).FirstOrDefault();
            if (controlLike != null)
            {
                _likeRepository.Remove(controlLike.LikeID);
                return null;
            }
            else
            {
                Like like = new Like
                {
                    LikeDate = DateTime.Now.Date,
                    EntryID = EntryID,
                    PersonID = PersonID
                };
                return _likeRepository.Add(like);
            }
        }
    }
}
