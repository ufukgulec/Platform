namespace Platform.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Entry")]
    public partial class Entry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entry()
        {
            Likes = new HashSet<Like>();
            Replies = new HashSet<Reply>();
        }

        public int EntryID { get; set; }

        [StringLength(50)]
        public string EntryTitle { get; set; }

        public string EntryArticle { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EntryDate { get; set; }

        public bool? IsValid { get; set; }

        public int? PersonID { get; set; }

        public int? TagID { get; set; }

        public virtual Person Person { get; set; }

        public virtual Tag Tag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Like> Likes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
