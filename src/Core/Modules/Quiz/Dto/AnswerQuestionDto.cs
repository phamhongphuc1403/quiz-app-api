using System.ComponentModel.DataAnnotations;
using quiz_app_api.src.Core.Enums;

namespace quiz_app_api.src.Core.Modules.Quiz.Dto
{
    public class AnswerQuestionDto
    {
        public int answer_id { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = InterceptorEnum.INVALID_TIME)]
        public double time_to_answer { get; set; }
    }
}
