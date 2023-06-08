using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace quiz_app_api.src.Core.Database.Models
{
    [Table("questions")]
    public class QuestionModel
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int id { get; set; }
        public string question { get; set; } = string.Empty;
        public virtual ICollection<UserQuestionModel> users_questions { get; set; }
        public virtual ICollection<AnswerModel> answers { get; set; }
        public QuestionModel()
        {
            users_questions = new List<UserQuestionModel>();
            answers = new List<AnswerModel>();
        }
    }
}
