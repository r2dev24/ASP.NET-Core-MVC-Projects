using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
