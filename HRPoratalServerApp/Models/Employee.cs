using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPoratalServerApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }

        public double Salary { get; set; }

        public DateTime DOJ { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
