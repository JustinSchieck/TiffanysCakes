namespace TiffanysCakesV4.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<CakeFlavour> CakeFlavours { get; set; }
        public virtual DbSet<Cake> Cakes { get; set; }
        public virtual DbSet<Flavour> Flavours { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cake>()
                .HasMany(e => e.CakeFlavours)
                .WithRequired(e => e.Cake)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flavour>()
                .HasMany(e => e.CakeFlavours)
                .WithRequired(e => e.Flavour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flavour>()
                .HasMany(e => e.Cakes)
                .WithRequired(e => e.Flavour)
                .WillCascadeOnDelete(false);
        }
    }
}
