using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Interfaces
{
    public interface ILikeService : IGenericService<Like>
    {
        /// <summary>
        /// Entry Like yoksa ekler varsa siler.
        /// </summary>
        /// <param name="EntryID">Beğenilen entry'nin Id'si</param>
        /// <param name="PersonID">Beğenen person'un Id'si</param>
        Like LikeOrDislike(int EntryID, int PersonID);
    }
}
