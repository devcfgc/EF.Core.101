using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWind.Entities
{
    public class Category
    {
        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }

        public int StoreID { get; set; }
        public int StoreLocationID { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)] --> It will have no value
        //[Column("ID")]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(220)]
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> NationalProducts { get; set; }
        public List<Product> ImportedProducts { get; set; }
        public DateTime Inserted { get; set; }
        public DateTime LastUpdated { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
