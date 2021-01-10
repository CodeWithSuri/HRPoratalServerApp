using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPoratalServerApp.Repositories;
using HRPoratalServerApp.Models;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.JsonPatch;

namespace HRPoratalServerApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        private IEmpRepo _empreo;


        public EmployeeController(IEmpRepo empRepo)
        {


            _empreo = empRepo;
        }

        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Employee> Get() =>_empreo.Employees;

        [HttpGet]
        [ActionName("AllEmps")]
        public IEnumerable<Employee> AllEmps() => _empreo.Employees;


        [HttpGet("{id}")]
        [ActionName("GetEmpByID")]
        public Employee GetEmpByID(int id) => _empreo[id];


        [HttpPost]
        [ActionName("Postemp")]
        public Employee Postemp([FromBody] Employee emp) => _empreo.AddEmp(new Employee
        {

            Department=emp.Department,
            DOJ=emp.DOJ,
            EmployeeId=emp.EmployeeId,
            FirstName=emp.FirstName,
           LastName=emp.LastName,
           LastUpdated=emp.LastUpdated,
           Position=emp.Position,
           Salary=emp.Salary
        });


        [HttpDelete("{id}")]
        [ActionName("DeleteempId")]
        public void DeleteempId(int id) => _empreo.DeleteEmp(id);



        [HttpPut("{id:int}")]
        [ActionName("PutEmp")]
        public Employee PutEmp(int id,[FromBody] Employee emp) => _empreo.updateEmp(new Employee
        {

            Department = emp.Department,
            DOJ = emp.DOJ,
            EmployeeId = emp.EmployeeId,
            FirstName = emp.FirstName,
            LastName = emp.LastName,
            LastUpdated = emp.LastUpdated,
            Position = emp.Position,
            Salary = emp.Salary
        });


    }
}
