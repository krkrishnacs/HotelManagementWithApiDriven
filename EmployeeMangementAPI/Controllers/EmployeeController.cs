using EmployeeMangementAPI.DataDbContext;
using EmployeeMangementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
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
        //[Route("getEmpById")]
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
        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            try
            {
                if (id !=0)
                {
                    return BadRequest($"Employee Id{id} is  Invalid");
                }
                _context.Entry(id).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok("Employee Update Sucessfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost,Route("UpdateEmployee")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateEmployeeRecod(int Id, Employee employee)
        {
            try
            {
                if (employee.Id == 0||employee == null)
                {
                    if (employee==null)
                    {
                        return BadRequest("Data is Invalid!");

                    }
                    else if (employee.Id==0)
                    {
                        return BadRequest($"Data Id{employee.Id} is Invalid!");
                    }
                }
                var emp = _context.Employees.Find(employee.Id);
                if (emp != null) 
                {
                    return NotFound($"Employee Not Found With {employee.Id}");
                }
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Email = employee.Email;
                emp.Address= employee.Address;
                emp.MobileNumber = employee.MobileNumber;
                emp.Designation= employee.Designation;
                _context.SaveChanges();
                return Ok("Employee Update Sucessfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete,Route("EmpDeleted")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = _context.Employees.Find(id);

                if (employee == null)
                {
                    return NotFound($"Employee Deatils Not Found with Id,{id}");
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
