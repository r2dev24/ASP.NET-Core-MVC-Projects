using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Employee_ID { get; set; }

        [Required]
        public string Employee_Name { get; set; }

        [Required]
        public DateTime Employee_BirthDate { get; set; }

        [Required]
        public string Employee_Phone { get; set; }

        [Required]
        public string Employee_Email { get; set; }

        public EmployeeAddressModel AddressModel { get; set; }
        public EmployeeEducationModel EducationModel { get; set; }
        public EmployeeCareerModel CareerModell { get; set; }
    }
}
