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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalesMan> SalesMen { get; set; }

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

            //Composite Foreign key
            modelBuilder.Entity<Category>()
                .HasKey(c => new { c.StoreID, c.CategoryId});
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => Products)
                .HasForeignKey(p => new {p.CategoryStore, p.CategoryId});

            //relationship between a foreign key and not a primary key
            //modelBuilder.Entity<Product>()
            //    .HasOne(p => p.Category)
            //    .WithMany(c => c.Products)
            //    .HasForeignKey(p => p.CategoryStore)
            //    .HasPrincipalKey(c => c.StoreID);

            //relationship between a composite foreign key and a composite not primary key
            //modelBuilder.Entity<Product>()
            //    .HasOne(p => p.Category)
            //    .WithMany(c => c.Products)
            //    .HasForeignKey(p => new {p.CategoryStore, p.CategoryStoreLocationID})
            //    .HasPrincipalKey(c => new {c.StoreID, c.StoreLocationID});

            //modelBuilder.Entity<Product>()
            //    .HasOne(p => p.Category)
            //    .WithMany(c => c.Products)
            //    .IsRequired();

            //Delete cascade
            //modelBuilder.Entity<Product>()
            //    .HasOne(p => p.Category)
            //    .WithMany(c => c.Products)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Product>()
            //    .HasOne(p => p.ProductImage)
            //    .WithOne(pi => pi.Product)
            //    .HasForeignKey<ProductImage>(pi => pi.ProductForeignKey);

            //Many to many - a table in the middle of to entities
            modelBuilder.Entity<ProductImage>()
                .HasKey(pi => new {pi.ImageID, pi.ProductID});

            modelBuilder.Entity<ProductImage>()
                .HasOne(pi => pi.Image)
                .WithMany(i => i.ProductImages)
                .HasForeignKey(pi => pi.ProductID);

            modelBuilder.Entity<ProductImage>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(pi => pi.ImageID);

            //Index

            //modelBuilder.Entity<Category>()
            //    .HasIndex(c => c.CategoryName)
            //    .IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(c => new {c.CategoryId, c.CategoryName});

            //Alternate keys
            modelBuilder.Entity<Product>()
                .HasAlternateKey(p => p.CommentsURL);

            //modelBuilder.Entity<Product>()
            //    .HasAlternateKey(p => new {p.StoreID, p.LocationID});

            //modelBuilder.Entity<Comment>()
            //    .HasOne(c => c.Product)
            //    .WithMany(p => p.Comments)
            //    .HasForeignKey(c => c.ProductCommentsURL)
            //    .HasPrincipalKey(p => p.CommentsURL);

            //Inheritance
            modelBuilder.Entity<SalesMan>()
                .HasBaseType<Employee>();
        }
    }
}
