namespace Platform.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            Entries = new HashSet<Entry>();
            Likes = new HashSet<Like>();
            Replies = new HashSet<Reply>();
        }

        public int PersonID { get; set; }
        [DisplayName("Ad?n?z")]
        [StringLength(50)]
        public string PersonName { get; set; }
        [DisplayName("Soyad?n?z")]
        [StringLength(100)]
        public string PersonSurname { get; set; }
        [DisplayName("E-mail")]
        public string PersonMail { get; set; }

        public string PersonImgUrl { get; set; }
        [DisplayName("Kullan?c? Ad?n?z")]
        [StringLength(50)]
        public string Username { get; set; }
        [DisplayName("Parolan?z")]
        public string Password { get; set; }

        public bool? IsValid { get; set; }

        public int? PersonTypeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entry> Entries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Like> Likes { get; set; }

        public virtual PersonType PersonType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
