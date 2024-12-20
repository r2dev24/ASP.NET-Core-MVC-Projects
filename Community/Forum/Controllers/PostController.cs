using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Forum.Controllers
{
    public class PostController : Controller
    {
        //Db
        private AppDbContext _context;

        //Constructor
        public PostController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> PostNotify(Notification model)
        {
            //Get User Account ID
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userEmail))
            {
                return Unauthorized("로그인 정보가 없습니다.");
            }

            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Account_Email == userEmail);

            if (account == null)
            {
                return NotFound("계정을 찾을 수 없습니다.");
            }

            var newPost = new Notification
            {
                Title = model.Title,
                Content = model.Content,
                Account_ID = account.Account_ID,
            };

            try
            {
                _context.Notifications.Add(newPost);
                _context.SaveChanges();

                return RedirectToAction("Notify", "Category");
            }
            catch (Exception ex) { 

                Console.WriteLine(ex.ToString());
            }

            return NotFound("계정을 찾을 수 없습니다.");
        }
    }
}
