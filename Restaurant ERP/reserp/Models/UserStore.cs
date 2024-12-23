using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserp.Models
{
    public class UserStore
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string StoreName { get; set; }

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
    }
}
