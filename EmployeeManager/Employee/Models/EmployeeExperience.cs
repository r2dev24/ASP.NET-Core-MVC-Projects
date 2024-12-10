using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Models
{
    public class EmployeeExperience
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public required Employees Employee { get; set; }
    }
}
