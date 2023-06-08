using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using quiz_app_api.src.Core.Ultils;
using quiz_app_api.src.Core.Enums;

namespace quiz_app_api.src.Core.Modules.Auth.Dto
{
    public class RegisterDto
    {
        [Required]
        [MaxLength(100)]
        public string username { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [RegularExpression(Regex.EMAIL, ErrorMessage = InterceptorEnum.INVALID_EMAIL)]
        public string email { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        [PasswordPropertyText]
        [DefaultValue("Password123!")]
        [RegularExpression(Regex.PASSWORD, ErrorMessage = InterceptorEnum.INVALID_PASSWORD)]
        public string password { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        [PasswordPropertyText]
        [DefaultValue("Password123!")]
        public string confirm_password { get; set; } = string.Empty;
    }
}
