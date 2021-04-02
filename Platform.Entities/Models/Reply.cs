using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Entities.Models
{
    public class Reply
    {
        public int ReplyID { get; set; }
        public string ReplyArticle { get; set; }
        public DateTime ReplyDate { get; set; }
        public bool ReplyIsValid { get; set; }
        public int EntryID { get; set; }
        public virtual Entry Entry { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
