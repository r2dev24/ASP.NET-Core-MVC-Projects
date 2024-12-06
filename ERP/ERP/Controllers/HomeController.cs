using System.Diagnostics;
using System.Security.Claims;
using ERP.Data;
using ERP.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //DbContext
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn(Account account) {
            var user = _context.Accounts.FirstOrDefault(a => a.Account_ID == account.Account_ID);

            //user validation
            if (user != null)
            {
                //Define Password Hasher
                var hasher = new PasswordHasher<object>();
                //Hashing User Password
                var hashed = hasher.HashPassword(null, account.Account_Password);
                //Hashing verifying
                var verify = hasher.VerifyHashedPassword(null, user.Account_Password, account.Account_Password);

                if (verify == PasswordVerificationResult.Success)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Account_ID),
                    new Claim(ClaimTypes.Role, "User")
                };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                    };

                    HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(identity), authProperties).Wait();

                    return RedirectToAction("Index", "Dashboard");
                }

                ViewBag.ErrorMessage = "아이디 또는 비밀번호가 잘 못되었습니다.";
                return RedirectToAction("Index", "Home");

            } else
            {
                ViewBag.ErrorMessage = "아이디 또는 비밀번호가 잘 못되었습니다.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync("CookieAuth"); 
            return RedirectToAction("Index", "Home"); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
