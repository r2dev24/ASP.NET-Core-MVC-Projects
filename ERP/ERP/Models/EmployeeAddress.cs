using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class EmployeeAddress
    {
        [Key]
        public int Address_ID { get; set; }

        [Required]
        public string Unit { get; set; } // 동/호

        [Required]
        public string StreetName { get; set; } // 도로명

        [Required]
        public string City { get; set; } // 도시

        [Required]
        public string Province { get; set; } // 도/시 (예: 경기도, 서울시)

        [Required]
        public string PostalCode { get; set; } // 우편번호

        [ForeignKey("Employee")]
        public int Employee_ID { get; set; }

        public Employee Employee { get; set; }
    }
}
