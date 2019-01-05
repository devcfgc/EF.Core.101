using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NorthWind.Entities;

namespace NorthWind.DAL
{
    public class NorthWindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // IF APP IS NET CORE USE THIS:
            //var projectDir = Directory.GetCurrentDirectory();
            var projectDir = AppDomain.CurrentDomain.BaseDirectory;
            IConfiguration configuration =
                new ConfigurationBuilder()
                    .SetBasePath(projectDir)
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

            optionsBuilder.UseSqlServer(
                // IF APP IS NET CORE
                configuration.GetConnectionString("NorthWindDatabase")

                //ELSE NET FRAMEWORK:
                //System.Configuration.ConfigurationManager.ConnectionStrings["NorthWindDatabase"].ConnectionString
            );
        }
    }
}
