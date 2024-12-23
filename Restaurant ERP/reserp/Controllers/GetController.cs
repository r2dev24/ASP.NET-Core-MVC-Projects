using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reserp.Data;
using reserp.Models;

namespace reserp.Controllers
{
    public class GetController : Controller
    {
        private readonly AppDbContext _context;

        public GetController(AppDbContext context)
        {
            _context = context;
        }
    }
}
