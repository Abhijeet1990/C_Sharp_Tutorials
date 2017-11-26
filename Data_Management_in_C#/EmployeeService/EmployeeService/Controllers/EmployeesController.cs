using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;

namespace EmployeeService.Controllers
{
    public class EmployeesController : ApiController
    {
        //This will respond to the URI HTTP GET request
        [Route("api/employees/{minSalary}/{maxSalary}")]
        public IEnumerable<Employee> Get(int minSalary,int maxSalary)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Employees.Where(x => x.Salary > minSalary && x.Salary < maxSalary).ToList();
            }
        }

        //This will respond to the 
        public Employee Get(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Employees.FirstOrDefault(e => e.ID == id);//return e whose ID is id
            }
        }
    }
}
