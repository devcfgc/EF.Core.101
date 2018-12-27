using Microsoft.EntityFrameworkCore;
using NorthWind.Entities;

namespace NorthWind.DAL.SQLLite
{
    public class NorthWindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=NorthWind.db");
        }
    }
}
