using Platform.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Dal.Concrete.EntityFramework.Context
{
    public class PlatformContext : DbContext
    {
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
