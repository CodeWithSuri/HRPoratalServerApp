using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPoratalServerApp.Models
{
    public class User
    {

        public string userName { get; set; }

        public string password { get; set; }

        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }

        public double Salary { get; set; }
        public DateTime DOJ { get; set; }

        public User()
        {
            userName = "Amar";
            password = "Amar123";
            EmployeeId = "emp1";
        }

        public bool ValidateUser(string username,string pwd)
        {

            if (username == userName && pwd == password)
                return true;
            else
                return false;
        }
    }
}
