using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using reserp.Data;
using reserp.Models;

namespace reserp.Controllers
{
    public class FranchiseController : Controller
    {
        private readonly AppDbContext _context;

        public FranchiseController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult AddStore()
        {
            var users = _context.Users.ToList();

            var user = _context.Users
                .Select(u => new SelectListItem
                {
                    Value = u.UserID.ToString(),
                    Text = u.UserName
                })
                .ToList();

            ViewData["Users"] = user;
            return View();
        }
    }
}
