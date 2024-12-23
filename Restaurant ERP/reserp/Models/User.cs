using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserp.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserPhone { get; set; }

        [ForeignKey("Account")]
        public int AccountID { get; set; }

        public Account Account { get; set; }
    }
}
