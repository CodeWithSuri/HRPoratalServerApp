using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPoratalServerApp.Models;

namespace HRPoratalServerApp.Repositories
{
    public class EmpRepo :IEmpRepo
    {

        private Dictionary<int, Employee> emps;


            public EmpRepo() {

            emps = new Dictionary<int, Employee>();
            new List<Employee> {
                new Employee{FirstName="Suri",LastName="L",Department="IT",
                    Salary=12522,EmployeeId=0,DOJ=DateTime.Now,LastUpdated=DateTime.Now,Position="SSE"},
                   new Employee{FirstName="Amar",LastName="T",Department="IT",
                       Salary=12522,EmployeeId=2,DOJ=DateTime.Now,LastUpdated=DateTime.Now,Position="TL"}
            }.ForEach(emp => AddEmp(emp));

        }

        public Employee this[int empid]=>emps.ContainsKey(empid)?emps[empid]:null;


        public IEnumerable<Employee> Employees => emps.Values;

        public Employee AddEmp(Employee addemp)
        {
            if (addemp.EmployeeId == 0)
            {

                int empcount = emps.Count;

                while (emps.ContainsKey(empcount))
                {

                    empcount++;
                    addemp.EmployeeId = empcount;
                }

             
            }
            emps[addemp.EmployeeId] = addemp;

            
            
            return addemp;

        }



        public  void DeleteEmp(int empid)
        {

            emps.Remove(empid);

        }

       public Employee updateEmp(Employee addemp)
        {


            return AddEmp(addemp);
        }
    }
}
