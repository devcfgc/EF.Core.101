using Microsoft.EntityFrameworkCore;
using NorthWind.Entities;

namespace NorthWind.DAL
{
    public class NorthWindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=NorthWind;Trusted_Connection=True"
            );
        }
    }
}
