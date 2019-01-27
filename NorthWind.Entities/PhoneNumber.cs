using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Entities
{
    //[Owned]
    public class PhoneNumber
    {
        public string CountryCode { get; set; }
        public string NationalCode { get; set; }
        public string Number { get; set; }
    }
}
