using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }

        public string DepartmentName { get; set; }
        public Department Department { get; set; }
    }
}
