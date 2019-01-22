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
        
        //Backing fields
        // _eMail, _Email, m_eMail, m_Email
        // To be modified we need to use the EF syntax for assignation:
        // Context.Entry(Employee).Property("Email").CurrentValue = devcfgc@devcfgc.com
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                //Validation
                _Email = value;
            }
        }


        // More on backing fields
        private string NewEmail;

        public string GetNewEmail()
        {
            return NewEmail;
        }

        public void SetNewEmail(string newEmail)
        {
            //Validation
            NewEmail = newEmail;
        }
    }
}
