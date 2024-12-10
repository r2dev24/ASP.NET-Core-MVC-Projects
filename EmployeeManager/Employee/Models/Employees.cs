using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
