using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Entities
{
    public class Image
    {
        public int ImageID { get; set; }
        public byte[] BytesImage { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
