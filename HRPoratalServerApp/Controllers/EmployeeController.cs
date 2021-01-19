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
using HRPoratalServerApp.RepositoryPattren;
using Microsoft.AspNetCore.Authorization;

namespace HRPoratalServerApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {

        private IRepositoryWrapper _repositoryWrapper;

        //private IEmpRepo _empreo;


        //  public EmployeeController(IEmpRepo empRepo,)
        public EmployeeController(IRepositoryWrapper repositoryWrapper)
        {


            _repositoryWrapper = repositoryWrapper;
        }



        [HttpGet]
        [ActionName("Get")]
        public IQueryable<Employee> Get() =>_repositoryWrapper.employeeRepositry.GetAllData();

        [HttpGet]
        [ActionName("AllEmps")]
        public IEnumerable<Employee> AllEmps() => _repositoryWrapper.employeeRepositry.GetAllData();


        [HttpGet("{id}")]
        [ActionName("GetEmpByID")]
        public IQueryable<Employee> GetEmpByID(int id) => _repositoryWrapper.employeeRepositry.FindByCondition(emp=>emp.EmployeeId.Equals(id));


        [HttpPost]
        [ActionName("Postemp")]
        public Employee Postemp([FromBody] Employee emp) => _repositoryWrapper.employeeRepositry.Create(new Employee
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
        public void DeleteempId([FromBody] Employee emp) => _repositoryWrapper.employeeRepositry.Delete(emp);



        [HttpPut("{id:int}")]
        [ActionName("PutEmp")]
        public Employee PutEmp(int id,[FromBody] Employee emp) => _repositoryWrapper.employeeRepositry.Update(new Employee
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
