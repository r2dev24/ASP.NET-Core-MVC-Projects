using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }
        public DbSet<EmployeeExperience> EmployeeExperiences { get; set; }
    }
}
