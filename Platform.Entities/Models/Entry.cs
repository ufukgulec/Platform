using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Entities.Models
{
    public class Entry
    {
        public int EntryID { get; set; }
        public string EntryTitle { get; set; }
        public string EntryArticle { get; set; }
        public DateTime EntryDate { get; set; }
        public bool EntryIsValid { get; set; }
        public int TagID { get; set; }
        public virtual Tag Tag { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public List<Reply> Replies { get; set; }
        public List<Like> Likes { get; set; }
    }
}
