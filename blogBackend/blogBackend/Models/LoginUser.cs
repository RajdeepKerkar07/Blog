using System.ComponentModel.DataAnnotations;

namespace blogBackend.Models
{
    public class LoginUser
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}
