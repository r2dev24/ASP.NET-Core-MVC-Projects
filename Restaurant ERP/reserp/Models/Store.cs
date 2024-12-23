using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserp.Models
{
    public class Store
    {
        [Key]
        public int StoreID { get; set; }

        [Required]
        public string StoreName { get; set; }

        [ForeignKey("Account")]
        public int AccountID { get; set; }

        public Account Account { get; set; }
    }
}
