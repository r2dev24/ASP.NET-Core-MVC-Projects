using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<EmployeeAddressModel> Addresses { get; set; }
        public DbSet<EmployeeEducationModel> Educations { get; set; }
        public DbSet<EmployeeCareerModel> Career { get; set; }
    }
}
