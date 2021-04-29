using BO;
using System.Data.Entity;

namespace Dojo.Data
{
    public class DojoContext : DbContext
    {    
        public DojoContext() : base("name=DojoContext")
        {
        }

        public DbSet<BO.Arme> Armes { get; set; }

        public DbSet<BO.Samourai> Samourais { get; set; }

        public DbSet<BO.ArtMartial> ArtsMartiaux { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Samourai>().HasOptional(x => x.Arme).WithOptionalPrincipal();
            modelBuilder.Entity<Samourai>().HasMany(x => x.ArtsMartiaux).WithMany();
        }
    }
}
