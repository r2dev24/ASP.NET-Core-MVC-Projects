using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Forum.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Notify()
        {
            var getPost = _context.Notifications.ToList();
            var getUser = _context.Users.ToList();

            var vmList = getPost.Select(post => new NotifyViewModel
            {
                Post_ID = post.Post_ID,
                Title = post.Title,
                Content = post.Content,
                User_NickName = getUser
                    .FirstOrDefault(user => user.Account_ID == post.Account_ID)?.User_NickName ?? "Unknown"
            }).ToList();

            return View(vmList);
        }

        public IActionResult CreateNotify()
        {
            return View("../../Views/Board/CreateNotify");
        }
    }
}
