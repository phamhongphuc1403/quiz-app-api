using quiz_app_api.src.Core.Database;
using quiz_app_api.src.Core.Database.Models;
using quiz_app_api.src.Core.Modules.Question;

namespace quiz_app_api.src.Core.Modules.Quiz.Service
{
    public class QuizService
    {
        private readonly QuizRepository quizRepository;
        private readonly QuestionRepository questionRepository;
        public QuizService(AppDbContext context)
        {
            quizRepository = new QuizRepository(context);
            questionRepository = new QuestionRepository(context);
        }
        public async Task<object> TakeQuiz(int userId)
        {
            var questions = questionRepository.GetQuestionList();

            List<QuizModel> quizzes = new List<QuizModel>();

            string quizId = Guid.NewGuid().ToString();

            foreach (var question in questions)
            {
                quizzes.Add(new QuizModel
                {
                    id = quizId,
                    user_id = userId,
                    question_id = question.id
                });
            }

            await quizRepository.CreateQuiz(quizzes);

            return new
            {
                data = new
                {
                    quiz_id = quizId,
                    questions = questions.Select(question => new
                    {
                        question.id,
                        question.question,
                        answers = question.answers.Select(answer => new
                        {
                            answer.id,
                            answer.answer
                        })
                    })
                }
            };
        }
    }
}
