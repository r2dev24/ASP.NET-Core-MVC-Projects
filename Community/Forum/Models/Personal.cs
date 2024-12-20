using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models
{
    public class Personal
    {
        [Key]
        public int Personal_Id { get; set; }

        [Required]
        public string Personal_Name { get; set; }

        [Required]
        public string Personal_Phone { get; set; }

        [Required]
        public DateTime Personal_Dob { get; set; }

        [ForeignKey("Account")]
        public int Account_ID { get; set; }

        public virtual Account Account { get; set; }
    }
}
