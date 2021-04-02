using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Entities.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
        public bool TagIsValid { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
