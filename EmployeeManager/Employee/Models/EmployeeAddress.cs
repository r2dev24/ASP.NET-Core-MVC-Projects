using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Models
{
    public class EmployeeAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Unit { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public required Employees Employee { get; set; }
    }
}
