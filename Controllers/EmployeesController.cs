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
        public IActionResult Create(Employee employee)
        {
            context.Employees.Add(employee);
            return Created();
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            if (context.Employees.FirstOrDefault(obj => obj.Id == id) == null)
                return NotFound( );
            context.Employees.ToList( ) [ id ] = employee;
            return Ok();
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id)
        {
            Employee employee = new Employee( );

            return Ok( );
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Employee? employee = context.Employees.FirstOrDefault(obj => obj.Id == id);
            if (employee == null)
                return NotFound( );
            context.Employees.Remove(employee);
            return Ok(id);
        }

    }
}
