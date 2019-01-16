using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NorthWind.DAL;
using NorthWind.Entities;

namespace NorthWind.ConsoleCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
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

                var product = context.Products.FirstOrDefault();
                //Shadow property
                var categoryId = context.Entry(product).Property("CategoryId").CurrentValue;
                //Get all categoryIds related to Products
                var categoryIdValues = context.Products.Select(p => EF.Property<int>(p, "CategoryId")).ToList();
                Console.Write($"{product.ProductName},{categoryId}");

                Console.ReadLine();
            }
        }
    }
}
