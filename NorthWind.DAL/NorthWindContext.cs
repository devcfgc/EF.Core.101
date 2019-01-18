using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NorthWind.Entities;

namespace NorthWind.DAL
{
    public class NorthWindContext : DbContext
    {
        ////IF we wan to use a custom NorthWindContext constructor
        //public NorthWindContext(DbContextOptions<NorthWindContext> options) : base(options)
        //{ }

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

            // IF Get connection string from config file
            //optionsBuilder.UseSqlServer(
            //    // IF APP IS NET CORE
            //    //configuration.GetConnectionString("NorthWindDatabase")

            //    //ELSE NET FRAMEWORK:
            //    System.Configuration.ConfigurationManager.ConnectionStrings["NorthWindDatabase"].ConnectionString
            //);

            // ELSE
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=NorthWind;Trusted_Connection=True",
                providerOptions => providerOptions.CommandTimeout(60)
            ).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>();
            //modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeNumber);
            //modelBuilder.Entity<Employee>().Ignore(e => e.LastUpdated);

            //modelBuilder.Ignore<Product>();
            //modelBuilder.Entity<Product>().Property<DateTime>("LastUpdated"); // definition of a shadow property
            //modelBuilder.Entity<Category>().Property(c => c.CategoryName).IsRequired();
            //modelBuilder.Entity<Category>().Property(c => c.CategoryName).HasMaxLength(300);
            //modelBuilder.Entity<Category>().Property(c => c.CategoryName).IsConcurrencyToken();
            //modelBuilder.Entity<Category>().Property(c => c.RowVersion).IsRowVersion();
            //modelBuilder.Entity<Category>().Property(c => c.CategoryId).ValueGeneratedNever();
            //modelBuilder.Entity<Category>().Property(c => c.Inserted).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Category>().Property(c => c.LastUpdated).ValueGeneratedOnAddOrUpdate();

            //modelBuilder.Entity<Category>().HasMany(c => c.NationalProducts).WithOne();
            modelBuilder.Entity<Category>().HasMany(c => c.NationalProducts).WithOne(p => p.NationalCategory);
            modelBuilder.Entity<Product>().HasOne(p => p.ImportedCategory).WithMany(c => c.ImportedProducts);

            //modelBuilder.Entity<Product>()
            //    .HasOne(p => p.Category)
            //    .WithMany(c => c.Products)
            //    .HasForeignKey(p => p.CategoryForeignKey);

        }
    }
}
