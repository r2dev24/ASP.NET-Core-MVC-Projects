using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reserp.Data;
using reserp.Models;

namespace reserp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SignIn(Account model)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountEmail == model.AccountEmail);

            if (account == null)
            {
                ViewBag.Error = "Invalid Information";
                return View("Index", model);
            }

            if (account.AccountPassword != model.AccountPassword)
            {
                ViewBag.Error = "Invalid password.";
                return View("Index", model);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.AccountID == account.AccountID);

            if (user == null)
            {
                ViewBag.Error = "Fail to sign in please contact with developer.";
                return View("Index", model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, account.AccountEmail), // 이메일
                new Claim(ClaimTypes.Name, user.UserName),         // 이름
                new Claim(ClaimTypes.Role, account.RoleID.ToString())             // 역할 추가
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Main");
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
