using Microsoft.EntityFrameworkCore;
using System;
using NorthWind.Entities;

namespace NorthWind.DAL.SQLite.Xamarin
{
    public class NorthWindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        private string _dbPath = "";

        public NorthWindContext(string dbPath)
        {
            _dbPath = dbPath;
        }

        public NorthWindContext() : this("NorthWind.db") {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
        }
    }
}
