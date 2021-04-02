using Platform.Entities.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Platform.Dal.Concrete.EntityFramework.Context
{
    public partial class PlatformContext : DbContext
    {
        public PlatformContext()
            : base("name=PlatformContext")
        {
        }

        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonType> PersonTypes { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
