using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Forum.Controllers
{
    public class ProfileController : Controller
    {
        //Db
        private AppDbContext _context;
        private PasswordHasher<Account> hasher = new PasswordHasher<Account>();

        //Constructor
        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        //Update Email
        [HttpPost]
        public async Task<IActionResult> UpdateEmail(AuthViewModel model)
        {
            var curEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var curNickName = User.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(curEmail))
            {
                return Unauthorized("현재 사용자의 이메일을 확인할 수 없습니다.");
            }

            // Checking User Information From DB
            var curUser = await _context.Accounts.FirstOrDefaultAsync(a => a.Account_Email == curEmail);

            if (curUser == null)
            {
                return NotFound("사용자를 찾을 수 없습니다.");
            }

            // New Email Verification
            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("Email", "유효한 이메일을 입력해주세요.");
                return View("Profile", model);
            }

            // Save New Email To curUser
            curUser.Account_Email = model.Email;

            try
            {
                // Update Database
                _context.Accounts.Update(curUser);
                await _context.SaveChangesAsync();

                // Update Claims (New Email)
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.Email), // save new email
                    new Claim(ClaimTypes.Name, curNickName)  // Keep nickname
                };

                var claimsIdentity = new ClaimsIdentity(claims, "login");
                await HttpContext.SignOutAsync();
                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Profile", "Auth");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ModelState.AddModelError("", "이메일 업데이트 중 오류가 발생했습니다.");
                return View("Profile", model);
            }
        }

        //Update Nick Name
        [HttpPost]
        public async Task<IActionResult> UpdateNickName(AuthViewModel model)
        {
            var curEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var curNickName = User.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(curNickName))
            {
                return Unauthorized("현재 사용자의 닉네임을 찾을 수 ");
            }

            var curUser = await _context.Users.FirstOrDefaultAsync(u => u.User_NickName == curNickName);

            if (curUser == null)
            {
                return NotFound("사용자를 찾을 수 없습니다.");
            }

            // New Nickname Verification
            if (string.IsNullOrEmpty(model.NickName))
            {
                ModelState.AddModelError("NickName", "닉네임을 입력해주세요.");
                return View("Profile", model);
            }


            curUser.User_NickName = model.NickName;

            try
            {
                // Update Database
                _context.Users.Update(curUser);
                _context.SaveChanges();

                // Update Claim
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, curEmail),
                    new Claim(ClaimTypes.Name, model.NickName) // 새 닉네임 저장
                };

                var claimsIdentity = new ClaimsIdentity(claims, "login");
                await HttpContext.SignOutAsync();
                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Profile", "Auth");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ModelState.AddModelError("", "닉네임 업데이트 중 오류가 발생했습니다.");
                return View("Profile", model);
            }
        }

        //Update Personal Information
        public async Task<IActionResult> UpdatePersonal(AuthViewModel model)
        {
            if (model.Personal.Personal_Name == null)
            {
                return View("~/Views/Auth/Profile.cshtml", model);
            } else if (model.Personal.Personal_Dob == null)
            {
                return View("~/Views/Auth/Profile.cshtml", model);
            } else if (model.Personal.Personal_Phone == null)
            {
                return View("~/Views/Auth/Profile.cshtml", model);
            }

            var curEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            if (curEmail == null)
            {
                return View("~/Views/Auth/Profile.cshtml", model);
            }

            // Checking User Information From DB
            var curUser = await _context.Accounts.FirstOrDefaultAsync(a => a.Account_Email == curEmail);

            if (curUser == null)
            {
                return View("~/Views/Auth/Profile.cshtml", model);
            }

            var pInfo = new Personal
            {
                Personal_Name = model.Personal.Personal_Name,
                Personal_Phone = model.Personal.Personal_Phone,
                Personal_Dob = model.Personal.Personal_Dob,
                Account_ID = curUser.Account_ID
            };

            try
            {
                _context.Personal_Info.Add(pInfo);
                await _context.SaveChangesAsync(); // 변경 사항 저장

                return RedirectToAction("Profile", "Auth");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View("~/Views/Auth/Profile.cshtml", model);
            }

        }

    }
}
