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
            return View();
        }

        [HttpPost]
        public IActionResult newEmployee(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Employee 객체를 먼저 데이터베이스에 추가
                var emp = new EmployeeModel
                {
                    Employee_Name = model.Employee_Name,
                    Employee_BirthDate = model.Employee_BirthDate,
                    Employee_Phone = model.Employee_Phone,
                    Employee_Email = model.Employee_Email,
                };

                _context.Add(emp);
                _context.SaveChanges(); // SaveChanges 호출로 Employee_ID가 생성됨

                // 생성된 Employee_ID를 사용하여 Address, Education, Career 데이터를 추가
                var addr = new EmployeeAddressModel
                {
                    Address_Unit = model.Address_Unit,
                    Address_Street = model.Address_Street,
                    Address_City = model.Address_City,
                    Address_Region = model.Address_Region,
                    Address_PostalCode = model.Address_PostalCode,
                    Employee_ID = emp.Employee_ID, // 데이터베이스에서 받은 Employee_ID
                };

                var edu = new EmployeeEducationModel
                {
                    Education_Status = model.Education_Status,
                    Education_School = model.Education_School,
                    Education_Major = model.Education_Major,
                    Employee_ID = emp.Employee_ID, // 데이터베이스에서 받은 Employee_ID
                };

                var career = new EmployeeCareerModel
                {
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CompanyName = model.CompanyName,
                    Department = model.Department,
                    JobTitle = model.JobTitle,
                    Employee_ID = emp.Employee_ID, // 데이터베이스에서 받은 Employee_ID
                };

                // Address, Education, Career 데이터를 추가
                _context.Add(addr);
                _context.Add(edu);
                _context.Add(career);

                _context.SaveChanges(); // 모든 변경사항을 데이터베이스에 저장

                return RedirectToAction("Index", "Employee"); // "Index"로 리다이렉트
            }

            return View("Index", "Employee");
        }



    }
}
