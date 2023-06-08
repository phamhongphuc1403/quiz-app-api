using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using quiz_app_api.src.Core.Database.Models;

namespace quiz_app_api.src.Core.Database.Model
{
    [Table("users")]

    public class UserModel
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int id { get; set; }
        [MaxLength(100)] public string username { get; set; } = string.Empty;
        [StringLength(250)] public string email { get; set; } = string.Empty;
        [MaxLength(250)] public string password { get; set; } = string.Empty;
        public string? refresh_token { get; set; } = string.Empty;
        public virtual ICollection<UserQuestionModel> users_questions { get; set; }
        public UserModel()
        {
            users_questions = new List<UserQuestionModel>();
        }
    }
}
