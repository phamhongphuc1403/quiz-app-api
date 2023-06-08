using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace quiz_app_api.src.Core.Modules.Auth.Dto
{
    public class LoginDto
    {
        [Required]
        [MaxLength(100)]
        public string username { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        [PasswordPropertyText]
        [DefaultValue("Password123!")]
        public string password { get; set; } = string.Empty;
    }
}
