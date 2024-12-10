using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Models
{
    public class EmployeeEducation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string SchoolName { get; set; }

        [Required]
        public string Major { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public required Employees Employee { get; set; }
    }
}
