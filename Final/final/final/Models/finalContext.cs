namespace final.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class finalContext : DbContext
    {
        public finalContext()
            : base("name=finalContext")
        {
        }

        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bid>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);
        }
    }
}
