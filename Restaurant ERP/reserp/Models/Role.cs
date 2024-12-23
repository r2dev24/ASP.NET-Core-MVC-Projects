using System.ComponentModel.DataAnnotations;

namespace reserp.Models
{
    public class Role
    {
        [Key]
        public int RoleID {  get; set; }

        [Required]
        public string Roles { get; set; }
    }
}
