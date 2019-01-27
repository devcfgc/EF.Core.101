using Microsoft.EntityFrameworkCore;

namespace NorthWind.Entities
{
    //[Owned]
    public class Customer
    {
        public Order Order { get; set; }
        public PhoneNumber HomePhone { get; set; }
        public PhoneNumber OfficePhone { get; set; }
    }
}
