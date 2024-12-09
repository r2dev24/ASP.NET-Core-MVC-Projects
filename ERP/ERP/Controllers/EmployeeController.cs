using ERP.Data;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Controllers
{
    public class EmployeeController : Controller
    {
        //DbContext
        private readonly AppDbContext _context;

        //Constructor
        public EmployeeController(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            // 직원 데이터 조회
            var employees = await _context.Employees.ToListAsync();

            return View(employees);
        }

        public IActionResult ApplyEmployee()
        {
            return View();
        }

        //Add Employee
        public async Task<IActionResult> AddEmployee(EmployeeViewModel empvm)
        {
            if (ModelState.IsValid) {
                var emp = new Employee
                {
                    Employee_Name = empvm.Employee_Name,
                    Employee_Englisth_Name = empvm.Employee_English_Name,
                    Employee_Phone = empvm.Employee_Phone,
                    Employee_Email = empvm.Employee_Email,
                    Employee_DateOfBirth = empvm.Employee_DateOfBirth,
                    Employee_JoinDate = empvm.Employee_JoinDate,
                    Employee_Sex = empvm.Employee_Sex,
                };

                var edu = new EmployeeEducation
                {
                    EducationStatus = empvm.EducationStatus,
                    School_Name = empvm.School_Name,
                    Employee = emp
                };

                var addr = new EmployeeAddress
                {
                    Unit = empvm.Unit,
                    StreetName = empvm.StreetName,
                    City = empvm.City,
                    Province = empvm.Province,
                    PostalCode = empvm.PostalCode,
                    Employee = emp
                };

                _context.Employees.Add(emp);
                _context.EmployeeEducation.Add(edu);
                _context.EmployeeAddresses.Add(addr);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Employee");
            } else
            {
                return View("ApplyEmployee", "Employee");
            }
        }

        //Detail
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.EmployeeEducation)
                .Include(e => e.EmployeeAddress)
                .FirstOrDefaultAsync(e => e.Employee_ID == id);

            if (employee == null)
            {
                return RedirectToAction("Index"); // No data, return to index of Employee
            }

            // Add Data To View Model
            var employeeViewModel = new EmployeeViewModel
            {
                Employee_ID = employee.Employee_ID,
                Employee_Name = employee.Employee_Name,
                Employee_Phone = employee.Employee_Phone,
                Employee_Email = employee.Employee_Email,
                Employee_DateOfBirth = employee.Employee_DateOfBirth,
                Employee_JoinDate = employee.Employee_JoinDate,
                Employee_Sex = employee.Employee_Sex,
                Employee_English_Name = employee.Employee_Englisth_Name,
                School_Name = employee.EmployeeEducation?.School_Name ?? "N/A",
                EducationStatus = employee.EmployeeEducation?.EducationStatus ?? "N/A",
                Unit = employee.EmployeeAddress?.Unit ?? "N/A",
                StreetName = employee.EmployeeAddress?.StreetName ?? "N/A",
                City = employee.EmployeeAddress?.City ?? "N/A",
                Province = employee.EmployeeAddress?.Province ?? "N/A",
                PostalCode = employee.EmployeeAddress?.PostalCode ?? "N/A"
            };

            return View("EmpDetail", employeeViewModel); // Send data to EmpDetailView
        }



    }
}
