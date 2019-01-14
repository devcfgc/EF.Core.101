using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWind.Entities
{
    public class Category
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] --> It will have no value
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
        public DateTime Inserted { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
