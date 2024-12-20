using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models
{
    public class Admin
    {
        [Key]
        public int Admin_ID { get; set; }

        [Required]
        public string Admin_Email { get; set; }

        [ForeignKey("Account")]
        public int Account_ID { get; set; }

        public virtual Account Account { get; set; }
    }
}
