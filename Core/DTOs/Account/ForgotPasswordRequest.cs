using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
