using quiz_app_api.src.Core.Database.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace quiz_app_api.src.Core.Database.Models
{
    [Table("quizzes")]
    public class QuizModel
    {
        public string id { get; set; } = string.Empty;
        public int user_id { get; set; }
        public int question_id { get; set; }
        public int? answer { get; set; }
        public double? time_to_answer { get; set; }
        public DateTime? created_at { get; set; } = DateTime.Now;
        public DateTime? updated_at { get; set; }
        public virtual UserModel user { get; set; }
        public virtual QuestionModel question { get; set; }
    }
}
