using Forum.Models;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data
{
    public class AppDbContext : DbContext
    {
        public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Personal> Personal_Info { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
