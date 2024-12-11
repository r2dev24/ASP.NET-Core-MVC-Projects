using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Models
{
    public class EmployeeEducationModel
    {
        [Key]
        public int Education_ID { get; set; }

        [Required]
        public string Education_Status { get; set; }

        [Required]
        public string Education_School { get; set; }

        [Required]
        public string  Education_Major { get; set; }

        [ForeignKey("EmployeeModel")]
        public int Employee_ID { get; set; }

        public EmployeeModel EmployeeModel { get; set; }
    }
}
