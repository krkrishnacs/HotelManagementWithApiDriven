using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementWeb.Controllers
{
    public class ReservationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
