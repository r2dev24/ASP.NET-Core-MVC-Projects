using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Forum.Controllers
{
    public class AuthController : Controller
    {
        //Db
        private AppDbContext _context;
        private PasswordHasher<Account> hasher = new PasswordHasher<Account>();

        //Constructor
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        //SignIn view
        public IActionResult SignIn()
        {
            return View();
        }

        //SignUp View
        public IActionResult SignUp()
        {
            return View();
        }

        //Profile View
        public IActionResult Profile()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userEmail))
            {
                return Unauthorized("이메일 정보를 찾을 수 없습니다.");
            }

            var user = _context.Accounts.FirstOrDefault(u => u.Account_Email == userEmail);

            if (user == null)
            {
                return NotFound("사용자 정보를 찾을 수 없습니다.");
            }

            var userNick = _context.Users.FirstOrDefault(a => a.Account_ID == user.Account_ID);

            if (userNick == null)
            {
                return NotFound("닉네임 정보를 찾을 수 없습니다.");
            }

            var personalInfo = _context.Personal_Info.FirstOrDefault(p => p.Account_ID == user.Account_ID);

            var vm = new AuthViewModel
            {
                Email = user.Account_Email,
                NickName = userNick.User_NickName,
                Personal = new Personal
                {
                    Personal_Name = personalInfo?.Personal_Name,
                    Personal_Phone = personalInfo?.Personal_Phone,
                    Personal_Dob = personalInfo?.Personal_Dob ?? DateTime.Now
                }
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> JoinMember(AuthViewModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View("SignUp", model);
            }

            var checkExisting = await _context.Accounts.FirstOrDefaultAsync(a => a.Account_Email == model.Email);

            if (checkExisting != null)
            {
                ModelState.AddModelError("Email", "이미 등록된 이메일입니다.");
                return View("SignUp", model);
            }

            var hashedPw = hasher.HashPassword(null, model.Password);

            var account = new Account
            {
                Account_Email = model.Email,
                Account_Password = hashedPw,
            };

            try
            {
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View("SignUp", model);
            }

            var user = new User
            {
                User_NickName = model.NickName,
                Account_ID = account.Account_ID,
            };

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("SignIn", "Auth");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View("SignUp", model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> MemberSignIn(Account acc)
        {
            if (ModelState.IsValid)
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Account_Email == acc.Account_Email);

                if (account != null) {
                    var verifyPw = hasher.VerifyHashedPassword(account, account.Account_Password, acc.Account_Password);

                    if (verifyPw == PasswordVerificationResult.Success) {
                        //Find user nickname
                        var user = await _context.Users.FirstOrDefaultAsync(u => u.Account_ID == account.Account_ID);

                        if (user != null)
                        {
                            var isAdmin = await _context.Admins.AnyAsync(a => a.Account_ID == account.Account_ID);

                            var claims = new List<Claim> {
                                new Claim(ClaimTypes.Email, account.Account_Email),
                                new Claim(ClaimTypes.Name, user.User_NickName),
                                new Claim("IsAdmin", isAdmin ? "true" : "false") // 관리자 여부 추가
                            };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                            HttpContext.Session.SetString("UserNickName", user.User_NickName);

                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "사용자 정보를 찾을 수 없습니다.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "비밀번호가 일치하지 않습니다.");
                    }
                } else
                {
                    ModelState.AddModelError("Email", "해당 이메일로 가입된 회원이 없습니다.");
                }
            }

            return View("SignIn", acc);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // 세션 데이터 삭제
            HttpContext.Session.Clear();

            // 인증 쿠키 삭제
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("SignIn", "Auth");
        }


    }
}
