using System.ComponentModel.DataAnnotations;

namespace JSONTokenLoginAPI.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
