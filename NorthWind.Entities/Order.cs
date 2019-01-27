using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public Customer Customer { get; set; }
    }
}
