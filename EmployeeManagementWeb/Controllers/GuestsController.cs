using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementWeb.Controllers
{
    public class GuestsController : Controller
    {
        [HttpGet]
        public IActionResult Guest()
        {
            return View();
        }
    }
}
