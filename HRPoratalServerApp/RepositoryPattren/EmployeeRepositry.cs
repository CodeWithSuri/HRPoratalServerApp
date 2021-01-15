using HRPoratalServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPoratalServerApp.RepositoryPattren
{
    public class EmployeeRepositry :RepositroyBase<Employee>,IEmployeeRepositry
    {

        public EmployeeRepositry(RepositryPattrenContext repositryPattren):base(repositryPattren)
        {

        }


        

    }
}
