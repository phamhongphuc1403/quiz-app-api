using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace quiz_app_api.src.Core.Database.Models
{
    [Table("answer")]
    public class AnswerModel
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int id { get; set; }
        public int question_id { get; set; }
        public string answer { get; set; } = string.Empty;
        public bool is_correct { get; set; }
        public virtual QuestionModel question { get; set; }
    }
}
