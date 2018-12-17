using NorthWind.DAL;
using NorthWind.Entities;
using System;

namespace NF.ConsoleApp.NewBD
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

                Console.ReadLine();
            }
        }
    }
}
