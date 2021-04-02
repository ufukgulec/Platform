namespace Platform.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reply")]
    public partial class Reply
    {
        public int ReplyID { get; set; }

        [StringLength(200)]
        public string ReplyArticle { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReplyDate { get; set; }

        public bool? IsValid { get; set; }

        public int? EntryID { get; set; }

        public int? PersonID { get; set; }

        public virtual Entry Entry { get; set; }

        public virtual Person Person { get; set; }
    }
}
