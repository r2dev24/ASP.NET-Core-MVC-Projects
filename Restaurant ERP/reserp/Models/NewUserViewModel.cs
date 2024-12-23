using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserp.Models
{
    public class NewUserViewModel
    {
        [Required]
        public string AccountEmail { get; set; }

        [Required]
        public string AccountPassword { get; set; }

        [Required]
        public int RoleID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserPhone { get; set; }

    }
}
