using Employee.Data;
using Employee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // 직원 데이터와 관련 데이터를 모두 로드
            var employees = _context.Employees
                .Include(e => e.AddressModel)
                .Include(e => e.EducationModel)
                .Include(e => e.CareerModell)
                .ToList();

            // ViewModel로 데이터 매핑
            var viewModel = new EmployeeViewModel
            {
                Employees = employees // 직원 목록 데이터를 ViewModel에 담음
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult newEmployee(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // 유효성 검사 실패 시 View에 모델 데이터를 다시 전달
                return View("Index", model);
            }

            try
            {
                var emp = new EmployeeModel
                {
                    Employee_Name = model.Employee_Name,
                    Employee_BirthDate = model.Employee_BirthDate,
                    Employee_Phone = model.Employee_Phone,
                    Employee_Email = model.Employee_Email,
                };

                _context.Add(emp);
                _context.SaveChanges();

                var addr = new EmployeeAddressModel
                {
                    Address_Unit = model.Address_Unit,
                    Address_Street = model.Address_Street,
                    Address_City = model.Address_City,
                    Address_Region = model.Address_Region,
                    Address_PostalCode = model.Address_PostalCode,
                    Employee_ID = emp.Employee_ID,
                };

                var edu = new EmployeeEducationModel
                {
                    Education_Status = model.Education_Status,
                    Education_School = model.Education_School,
                    Education_Major = model.Education_Major,
                    Employee_ID = emp.Employee_ID,
                };

                var career = new EmployeeCareerModel
                {
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CompanyName = model.CompanyName,
                    Department = model.Department,
                    JobTitle = model.JobTitle,
                    Employee_ID = emp.Employee_ID,
                };

                _context.Add(addr);
                _context.Add(edu);
                _context.Add(career);
                _context.SaveChanges();

                return RedirectToAction("Index", "Employee");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return View("Index", model);
            }
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = _context.Employees
                .Include(e => e.AddressModel)
                .Include(e => e.EducationModel)
                .Include(e => e.CareerModell)
                .FirstOrDefault(e => e.Employee_ID == id);

            if (employee == null)
            {
                return NotFound(); // 직원 데이터가 없을 경우 404 반환
            }

            return PartialView("_DetailEmployee", employee);
        }


    }
}
