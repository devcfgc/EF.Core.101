using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Entities
{
    //[Owned]
    public class Website
    {

        public string URL { get; set; }
        public string Title { get; set; }
    }
}
