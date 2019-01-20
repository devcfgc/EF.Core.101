using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Entities
{
   public  class ProductImage
    {
        //public int ProductImageID { get; set; }
        //public byte[] Image { get; set; }
        //public string Caption { get; set; }
        //public int ProductForeignKey { get; set; }
        //public Product Product { get; set; }

        public int ProductID { get; set; }
        public int ImageID { get; set; }
        public Product Product { get; set; }
        public Image Image { get; set; }
    }
}
