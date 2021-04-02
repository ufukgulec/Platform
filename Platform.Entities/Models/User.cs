using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Entities.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserMail { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool UserIsValid { get; set; }
        public List<Entry> Entries { get; set; }
        public List<Reply> Replies { get; set; }
        public List<Like> Likes { get; set; }
    }
}
