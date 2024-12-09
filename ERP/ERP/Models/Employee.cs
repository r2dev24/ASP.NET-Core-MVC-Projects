using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Employee
    {
        [Key]
        public int Employee_ID { get; set; }

        [Required]
        public string Employee_Name { get; set; }

        [Required]
        public string Employee_Phone {  get; set; }

        [Required]
        public string Employee_Email { get; set; }

        [Required]
        public DateOnly Employee_DateOfBirth { get; set; }

        [Required]
        public  DateOnly Employee_JoinDate {  get; set; }

        [Required]
        public string Employee_Sex { get; set; }

        public string Employee_Englisth_Name { get; set; }

        public EmployeeAddress EmployeeAddress { get; set; }
        public EmployeeEducation EmployeeEducation { get; set; }
    }
}
