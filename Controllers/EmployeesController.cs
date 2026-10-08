using Microsoft.AspNetCore.Mvc;

namespace Konkov_prakt6.Controllers
{
    [ApiController]
    [Route("api/v5/[controller]")]
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
            context.Employees.ToList( ) [ id ] = employee;
            return Ok();
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id)
        {
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
