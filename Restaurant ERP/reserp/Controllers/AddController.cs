using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using reserp.Data;
using reserp.Models;

namespace reserp.Controllers
{
    public class AddController : Controller
    {
        private readonly AppDbContext _context;

        public AddController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(NewUserViewModel model)
        {
            if (!ModelState.IsValid) {
                return View("Settings", "Main");
            }

            var account = new Account { 
                AccountEmail = model.AccountEmail,
                AccountPassword = model.AccountPassword,
                RoleID = model.RoleID
            };

            try
            {
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();

                var user = new User
                {
                    UserName = model.UserName,
                    UserPhone = model.UserPhone,
                    AccountID = account.AccountID,
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Main");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return View("Settings", "Main");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStore(UserStore model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Users"] = _context.Users.Select(u => new SelectListItem
                {
                    Value = u.UserName,
                    Text = u.UserName
                }).ToList();

                return View("Settings", "Main");
            }


            if (string.IsNullOrWhiteSpace(model.UserName))
            {
                ModelState.AddModelError("UserName", "UserName is required.");
                return View("Settings", "Main");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                return View("Settings", "Main");
            }

            var newStore = new Store
            {
                StoreName = model.StoreName,
                AccountID = user.AccountID
            };

            try
            {
                _context.Stores.Add(newStore);
                await _context.SaveChangesAsync();

                var newAddress = new StoreLocation
                {
                    StreetNumber = model.StreetNumber,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    Province = model.Province,
                    PostalCode = model.PostalCode,
                    StoreID = newStore.StoreID,
                };

                _context.Locations.Add(newAddress);
                await _context.SaveChangesAsync();

                return RedirectToAction("Franchise", "Main");
            }
            catch (Exception ex) {
                return View("Settings", "Main");
            }
        }


    }
}
