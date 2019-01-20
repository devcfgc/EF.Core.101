using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        //[ForeignKey("CategoryForeignKey")]
        //public Category Category { get; set; } // CategoryID is the shadow property for this entity
        [InverseProperty("NationalProducts")]
        public Category NationalCategory { get; set; }
        [InverseProperty("ImportedProducts")]
        public Category ImportedCategory { get; set; }

        //public int CategoryForeignKey { get; set; }
        public Category Category { get; set; }
        public int CategoryStore { get; set; }
        public int CategoryStoreLocationID { get; set; }

        public ProductImage ProductImage { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Comment> Comments { get; set; }
        public string CommentsURL { get; set; }
        public int StoreID { get; set; }
        public int LocationID { get; set; }

    }
}
