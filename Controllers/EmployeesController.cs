using Microsoft.AspNetCore.Mvc;

namespace Konkov_prakt6.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController : Controller
    {
        static WebApiDatabaseContext context = new WebApiDatabaseContext( );

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> employees = context.Employees.ToList( );
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Employee? employee = context.Employees.FirstOrDefault(obj => obj.Id == id);
            if (employee == null)
                return NotFound( );
            return Ok(employee);
        }



        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            if (context.Employees.FirstOrDefault(obj => obj.Id == employee.Id) != null)
                return BadRequest( );
            if (employee != null)
            {
                context.Employees.Add(employee);
                context.SaveChanges( );
                return Created();
            }
            return BadRequest( );
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Employee employee)
        {
            Employee? employees = context.Employees.FirstOrDefault(obj => obj.Id == id);
            if (employees != null && employee != null)
            {
                employees.FullName = employee.FullName;
                employees.Position = employee.Position;
                employees.Salary = employee.Salary;
                employee.HireDate = employee.HireDate;
                employees.IsActive = employee.IsActive;
            }
            context.SaveChanges( );
            return Ok(employees);
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, EmployeeDto employeeDto)
        {
            Employee? employee = context.Employees.FirstOrDefault(obj => obj.Id == id);
            if (employee == null)
                return NotFound( );

            if (employeeDto.FullName != null)
            {
                employee.FullName = employeeDto.FullName;
            }
            if (employeeDto.Position != null)
            {
                employee.Position = employeeDto.Position;
            }
            if (employeeDto.Salary != null)
            {
                employee.Salary = (decimal)employeeDto.Salary;
            }
            if (employeeDto.HireDate != null)
            {
                employee.HireDate = (DateOnly)employeeDto.HireDate;
            }
            if (employeeDto.IsActive != null)
            {
                employee.IsActive = (bool)employeeDto.IsActive;
            }

            context.SaveChanges( );

            return Ok( );
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Employee? employee = context.Employees.FirstOrDefault(obj => obj.Id == id);
            if (employee == null)
                return NotFound( );
            context.Employees.Remove(employee);
            context.SaveChanges( );
            return NoContent();
        }

    }
}
