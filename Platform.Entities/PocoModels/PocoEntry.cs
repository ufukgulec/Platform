using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Entities.PocoModels
{
    public class PocoEntry
    {
        public int EntryID { get; set; }
        public string EntryTitle { get; set; }
        public string EntryArticle { get; set; }
        public DateTime? EntryDate { get; set; }
        public bool? IsValid { get; set; }
        public int? PersonID { get; set; }
        public int? TagID { get; set; }
        public Person Person { get; set; }
        public Tag Tag { get; set; }
        public List<Like> Likes { get; set; }
        public List<Reply> Replies { get; set; }
    }
}
