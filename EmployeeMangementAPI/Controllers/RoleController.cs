using EmployeeMangementAPI.Models;
using EmployeeMangementAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleRepository _roleRepository;
        //public RoleController(RoleRepository roleRepository)
        //{
        //    _roleRepository = roleRepository;
        //}
        //[HttpGet]
        //public ActionResult<IEnumerable<Role>> GetRoles()
        //{
        //    return Ok(_roleRepository.GetAllRoles());
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Role> GetRole(int id)
        //{
        //    var role = _roleRepository.GetRoleById(id);
        //    if (role == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(role);
        //}

        //[HttpPost]
        //public ActionResult<Role> CreateRole(Role role)
        //{
        //    _roleRepository.AddRole(role);
        //    return CreatedAtAction(nameof(GetRole), new { id = role.RoleID }, role);
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateRole(int id, Role role)
        //{
        //    if (id != role.RoleID)
        //    {
        //        return BadRequest();
        //    }

        //    _roleRepository.UpdateRole(role);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteRole(int id)
        //{
        //    var role = _roleRepository.GetRoleById(id);
        //    if (role == null)
        //    {
        //        return NotFound();
        //    }

        //    _roleRepository.DeleteRole(id);
        //    return NoContent();
        //}
    }
}
