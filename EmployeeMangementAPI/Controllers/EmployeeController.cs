using EmployeeMangementAPI.DataDbContext;
using EmployeeMangementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EmployeeMangementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AccountDbContext _context;

        public EmployeeController(AccountDbContext context)
        {
            _context = context;
        }
        [HttpGet("getAllEmployeeDeatils")]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {

            try
            {
                var employee = _context.Employees.ToList();
                if (employee.Count == 0)
                {
                    return NotFound($"Employee Not Found");
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound($"Employee Deatils Not Found with Id,{id}");
            }

            return employee;
        }
        [HttpPost("addEmployee")]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }
        [HttpPut("{id}editEmployeeDeatils")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.Id)
                {
                    return BadRequest($"Employee Id{employee.Id} is  Invalid");
                }
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok("Employee Update Sucessfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id},deleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = _context.Employees.Find(id);

                if (employee == null)
                {
                    return NotFound("Employee Deatils Not Found with Id,{id}");
                }

                _context.Employees.Remove(employee);
                _context.SaveChanges();

                return Ok("Employee Deleted Sucessfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
