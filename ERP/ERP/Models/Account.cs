using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Account
    {
        [Key]
        public int Account_Number { get; set; }

        [Required]
        public string Account_ID { get; set; }

        [Required]
        public string Account_Password { get; set; }
    }
}
