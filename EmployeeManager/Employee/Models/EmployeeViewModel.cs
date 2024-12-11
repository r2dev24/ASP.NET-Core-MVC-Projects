using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class EmployeeViewModel
    {
        [Required]
        public string Employee_Name { get; set; }

        [Required]
        public DateTime Employee_BirthDate { get; set; }

        [Required]
        public string Employee_Phone { get; set; }

        [Required]
        public string Employee_Email { get; set; }

        [Required]
        public string Address_Unit { get; set; }

        [Required]
        public string Address_Street { get; set; }

        [Required]
        public string Address_City { get; set; }

        [Required]
        public string Address_Region { get; set; }

        [Required]
        public string Address_PostalCode { get; set; }

        [Required]
        public string Education_Status { get; set; }

        [Required]
        public string Education_School { get; set; }

        [Required]
        public string Education_Major { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string JobTitle { get; set; }

    }
}
