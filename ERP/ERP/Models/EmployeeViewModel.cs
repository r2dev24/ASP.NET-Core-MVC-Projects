using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class EmployeeViewModel
    {
        // Employee 기본 정보
        public int Employee_ID { get; set; }

        [Required]
        public string Employee_Name { get; set; }

        [Phone]
        public string Employee_Phone { get; set; }

        [EmailAddress]
        public string Employee_Email { get; set; }

        [Display(Name = "Date of Birth")]
        public DateOnly Employee_DateOfBirth { get; set; }

        [Display(Name = "Join Date")]
        public DateOnly Employee_JoinDate { get; set; }

        public string Employee_Sex { get; set; }

        public string Employee_English_Name { get; set; }

        [Required]
        public string School_Name { get; set; }

        [Required]
        public string EducationStatus { get; set; }

        [Required]
        public string Unit { get; set; } // 동/호

        [Required]
        public string StreetName { get; set; } // 도로명

        [Required]
        public string City { get; set; } // 도시

        [Required]
        public string Province { get; set; } // 도/시

        [Required]
        public string PostalCode { get; set; } // 우편번호
    }
}
