using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWind.Entities
{
    public class Employee
    {
        public string EmployeeID { get; set; }
        //[Key]
        public string RFC { get; set; }
        public string EmployeeNumber { get; set; }
        //[NotMapped]
        public bool IsInDatabase { get; set; }
        public DateTime LastUpdated { get; set; }
        public string FullName { get; }
    }
}
