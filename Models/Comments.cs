using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Comments

    {
        [Key]
        public int CommentID { get; set; }
        public int? UserID { get; set; }
        // Navigation
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Users? Users{ get; set; }
    }
}