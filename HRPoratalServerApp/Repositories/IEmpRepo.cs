using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPoratalServerApp.Models;
namespace HRPoratalServerApp.Repositories
{
   public interface IEmpRepo
    {

       public IEnumerable<Employee> Employees { get; }
       public Employee this[int empid] { get; }
        public Employee AddEmp(Employee addemp);
        public Employee updateEmp(Employee addemp);
        void DeleteEmp(int empid);


    }
}
