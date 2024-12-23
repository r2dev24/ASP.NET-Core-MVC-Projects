using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserp.Models
{
    public class StoreLocation
    {
        [Key]
        public int StoreLocationID { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [ForeignKey("Store")]
        public int StoreID { get; set; }

        public Store Store { get; set; }
    }
}
