using NorthWind.DAL;
using NorthWind.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NorthWind.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ////IF we wan to use a custom NorthWindContext constructor
            //var optionsBuilder = new DbContextOptionsBuilder<NorthWindContext>();
            //optionsBuilder.UseSqlServer(
            //    @"Server=(localdb)\MSSQLLocalDB;Database=NorthWind;Trusted_Connection=True",
            //    providerOptions => providerOptions.CommandTimeout(60)
            //).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            //using (var context = new NorthWindContext(optionsBuilder.Options))
            //{
            //}

            using (var context = new NorthWindContext())
            {
                Console.WriteLine("Category name:");
                var categoryName = Console.ReadLine();
                var categoryNew = new Category
                {
                    CategoryName = categoryName
                };
                context.Categories.Add(categoryNew);
                context.SaveChanges();

                Console.WriteLine("Categories:");
                foreach (var category in context.Categories)
                {
                    Console.WriteLine($"{category.CategoryId}, {category.CategoryName}");
                }

                //Get data from field with no property
                var eMails = context.Employees.Select(
                    e => EF.Property<string>(e, "Email")
                ).ToList();

                Console.ReadLine();
            }
        }
    }
}
