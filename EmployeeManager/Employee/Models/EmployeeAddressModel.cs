using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Models
{
    public class EmployeeAddressModel
    {
        [Key]
        public int Address_ID { get; set; }

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

        [ForeignKey("EmployeeModel")]
        public int Employee_ID { get; set; }

        public EmployeeModel EmployeeModel { get; set; }
    }
}
