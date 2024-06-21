using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string FullNames { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public List<Comments> Comments { get; set; } = new List<Comments>();
    }
}