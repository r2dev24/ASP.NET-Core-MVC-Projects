using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models
{
    public class Notification
    {
        [Key]
        public int Post_ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey("Account")]
        public int Account_ID { get; set; }

        public virtual Account Account { get; set; }
    }
}
