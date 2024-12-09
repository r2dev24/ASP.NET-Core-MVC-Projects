using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class EmployeeEducation
    {
        [Key]
        public int EmpEdu_ID { get; set; }

        [Required]
        public string School_Name { get; set; }

        [Required]
        public string EducationStatus { get; set; }

        [ForeignKey("Employee")]
        public int Employee_ID { get; set; }

        public Employee Employee { get; set; }
    }
}
