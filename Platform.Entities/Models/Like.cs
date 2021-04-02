namespace Platform.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Like")]
    public partial class Like
    {
        public int LikeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LikeDate { get; set; }

        public int? EntryID { get; set; }

        public int? PersonID { get; set; }

        public virtual Entry Entry { get; set; }

        public virtual Person Person { get; set; }
    }
}
