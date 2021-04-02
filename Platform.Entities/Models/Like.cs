using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Entities.Models
{
    public class Like
    {
        public int LikeID { get; set; }
        public DateTime LikeDate { get; set; }
        public int EntryID { get; set; }
        public virtual Entry Entry { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
