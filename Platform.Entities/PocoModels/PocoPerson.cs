using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Entities.PocoModels
{
    [NotMapped]
    public class PocoPerson
    {
        public int PersonID { get; set; }
        public string Username { get; set; }
        public int PersonTypeID { get; set; }
    }
}
