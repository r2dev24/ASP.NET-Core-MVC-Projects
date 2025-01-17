﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserp.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }

        [Required]
        public string AccountEmail { get; set; }

        [Required]
        public string AccountPassword { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
