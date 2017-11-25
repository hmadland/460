using System;
using System.Data.Entity;

namespace HW7.Models
{
    public partial class GiphyDBContext : DbContext
    {
        public GiphyDBContext()
            : base("name=GiphyDBContext")
        { 
        }
        public virtual DbSet<GiphyLog> GiphyLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiphyLog>()
                .Property(e => e.queryClientAgent)
                .IsUnicode(false);

            modelBuilder.Entity<GiphyLog>()
                .Property(e => e.giphyQuery)
                .IsUnicode(false);
        }
    }
}