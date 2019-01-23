//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using NorthWind.Entities;

//namespace NorthWind.DAL
//{
//    public class Category
//    {
//        public Category(string categoryName, NorthWindContext context)
//        {
//            CategoryName = categoryName;
//            Context = context;
//        }

//        private NorthWindContext Context;

//        public int StoreID { get; set; }
//        public int StoreLocationID { get; set; }

//        //[DatabaseGenerated(DatabaseGeneratedOption.None)] --> It will have no value
//        public int CategoryId { get; set; }
//        [Required]
//        [MaxLength(220)]
//        public string CategoryName { get; set; }
//        public List<Product> Products { get; set; }
//        public List<Product> NationalProducts { get; set; }
//        public List<Product> ImportedProducts { get; set; }
//        public DateTime Inserted { get; set; }
//        public DateTime LastUpdated { get; set; }
//        [Timestamp]
//        public byte[] RowVersion { get; set; }

//        public int ProductsCount
//        {
//            get
//            {
//                var Result = Products?.Count ?? 
//                             Context?.Products.Count
//                                 (p => EF.Property<int>(p, "CategoryID") == CategoryId) ?? 0;
//                return Result;
//            }
//        }
//    }
//}
