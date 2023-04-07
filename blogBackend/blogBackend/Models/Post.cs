using System;
using System.ComponentModel.DataAnnotations;

namespace blogBackend.Models
{
    public class Post
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public DateTime dateposted { get; set; }

        [Required]
        public string author { get; set; }
    }
}
