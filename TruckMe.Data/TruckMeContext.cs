namespace TruckMe.Data
{
    using Microsoft.EntityFrameworkCore;
    using TruckMe.Core;

    public class TruckMeContext : DbContext
    {
        // Entities
        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=.\SQLEXPRESS;Database=TruckMeDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
