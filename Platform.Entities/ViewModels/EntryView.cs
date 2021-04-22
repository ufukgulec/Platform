using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Entities.ViewModels
{
    [NotMapped]
    public class EntryView
    {
        public int EntryID { get; set; }
        public string EntryTitle { get; set; }
        public string EntryArticle { get; set; }
        public DateTime? EntryDate { get; set; }

        public bool? IsValid { get; set; }

        public int? PersonID { get; set; }

        public int? TagID { get; set; }
    }
}
