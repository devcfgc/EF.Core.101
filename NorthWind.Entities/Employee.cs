using System.ComponentModel.DataAnnotations;

namespace NorthWind.Entities
{
    public class Employee
    {
        public string EmployeeID { get; set; }
        //[Key]
        public string RFC { get; set; }
        public string EmployeeNumber { get; set; }
    }
}
