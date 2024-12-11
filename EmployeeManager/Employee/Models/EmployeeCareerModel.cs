using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Models
{
    public class EmployeeCareerModel
    {
        [Key]
        public int Career_ID { get; set; }

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

        [ForeignKey("EmployeeModel")]
        public int Employee_ID { get; set; }

        public EmployeeModel EmployeeModel { get; set; }
    }
}
