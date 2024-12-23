using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using reserp.Data;
using reserp.Models;
using System.Security.Cryptography.X509Certificates;

namespace reserp.Controllers
{
    [Authorize] //This controller need user authentication
    public class MainController : Controller
    {
        private readonly AppDbContext _context;

        public MainController(AppDbContext context)
        {
            _context = context;
        }

        //Dashboard View
        public IActionResult Index()
        {
            var users = _context.Users.Count();
            var stores = _context.Stores.Count();

            var userCount = new DashboardViewModel
            {
                UserCount = users,
                StoreCount = stores
            };
            
            return View(userCount);
        }

        //Financial View
        public IActionResult Financial()
        {
            return View();
        }

        //Franchise View
        public IActionResult Franchise(int page = 1, int pageSize = 10)
        {
            var accounts = _context.Accounts.ToList();
            var users = _context.Users.ToList();
            var store = _context.Stores.ToList();
            var location = _context.Locations.ToList();

            var newUserViewModels = accounts.Select(account => new NewUserViewModel
            {
                AccountEmail = account.AccountEmail,
                AccountPassword = account.AccountPassword,
                RoleID = account.RoleID,
                UserName = users.FirstOrDefault(user => user.AccountID == account.AccountID)?.UserName ?? "No Name",
                UserPhone = users.FirstOrDefault(user => user.AccountID == account.AccountID)?.UserPhone ?? "No Phone"
            }).ToList();

            var user = _context.Users
                .Select(u => new SelectListItem
                {
                    Value = u.UserID.ToString(),
                    Text = u.UserName
                })
                .ToList();

            var stores = store.Select(store => new UserStore
            {
                StoreName = store.StoreName,
                StreetNumber = location.FirstOrDefault(location => location.StoreID == store.StoreID)?.StreetNumber ?? "No Value",
                StreetAddress = location.FirstOrDefault(location => location.StoreID == store.StoreID)?.StreetAddress ?? "No Value",
                City = location.FirstOrDefault(location => location.StoreID == store.StoreID)?.City ?? "No Value",
                Province = location.FirstOrDefault(location => location.StoreID == store.StoreID)?.Province ?? "No Value",
                PostalCode = location.FirstOrDefault(location => location.StoreID == store.StoreID)?.PostalCode ?? "No Value",
                UserName = users.FirstOrDefault(u => u.AccountID == store.AccountID).UserName ?? "No Value",
            }).ToList();

            // 페이지네이션 로직
            var totalStores = stores.Count;
            var pagedStores = stores
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewData["Stores"] = pagedStores;
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling((double)totalStores / pageSize);
            ViewData["Users"] = user;
            ViewData["NewUserViewModels"] = newUserViewModels;

            return View();
        }


        //Inventory View
        public IActionResult Inventory()
        {
            return View();
        }

        //Employee view
        public IActionResult Employee()
        {
            return View();
        }

        //Settings View
        public IActionResult Settings()
        {
            var accounts = _context.Accounts.ToList();
            var users = _context.Users.ToList();
            var store = _context.Stores.ToList();
            var location = _context.Locations.ToList();

            var newUserViewModels = accounts.Select(account => new NewUserViewModel
            {
                AccountEmail = account.AccountEmail,
                AccountPassword = account.AccountPassword,
                RoleID = account.RoleID,
                UserName = users.FirstOrDefault(user => user.AccountID == account.AccountID)?.UserName ?? "No Name",
                UserPhone = users.FirstOrDefault(user => user.AccountID == account.AccountID)?.UserPhone ?? "No Phone"
            }).ToList();

            var user = _context.Users
                .Select(u => new SelectListItem
                {
                    Value = u.UserID.ToString(), 
                    Text = u.UserName      
                })
                .ToList();

            var stores = store.Select(store => new UserStore
            {
                StoreName = store.StoreName,
                StreetNumber = location.FirstOrDefault(location => location.StoreID == store.StoreID)?.StreetNumber ?? "No Value",
                StreetAddress = location.FirstOrDefault(location => location.StoreID == store.StoreID)?.StreetAddress ?? "No Value",
                City = location.FirstOrDefault(location => location.StoreID == store.StoreID)?.City ?? "No Value",
                Province = location.FirstOrDefault(location => location.StoreID == store.StoreID)?.Province ?? "No Value",
                PostalCode = location.FirstOrDefault(location => location.StoreID == store.StoreID)?.PostalCode ?? "No Value",
                UserName = users.FirstOrDefault(u => u.AccountID == store.AccountID).UserName ?? "No Value",
            });

            ViewData["Stores"] = stores;

            ViewData["Users"] = user;

            ViewData["NewUserViewModels"] = newUserViewModels;
            return View();
        }
    }
}
