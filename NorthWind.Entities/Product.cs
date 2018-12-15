using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NorthWind.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
