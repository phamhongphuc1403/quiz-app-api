using quiz_app_api.src.Core.Database;
using quiz_app_api.src.Core.Database.Models;
using quiz_app_api.src.Core.Modules.Question;
using quiz_app_api.src.Core.Modules.Quiz.Dto;
using quiz_app_api.src.Core.Ultils;
using quiz_app_api.src.Packages.HttpExceptions;

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
        public async Task<object> ValidateAnswer(string quizId, int questionId, int userId, AnswerQuestionDto model)
        {
            QuizModel quiz = Optional.Of(questionRepository.GetQuestionByIdAndQuizIdAndUserId(questionId, quizId, userId)).ThrowIfNotPresent(new BadRequestException(QuizEnum.QUESTION_NOT_FOUND)).Get();

            if (quiz.answer != null)
            {
                throw new BadRequestException(QuizEnum.ALREADY_ANSWERED);
            }

            AnswerModel answer = Optional.Of(questionRepository.GetAnswerByIdAndQuestionid(model.answer_id, questionId)).ThrowIfNotPresent(new BadRequestException(QuizEnum.ANSWER_NOT_FOUND)).Get();

            quiz.answer = model.answer_id;

            quiz.time_to_answer = model.time_to_answer;

            await quizRepository.SaveChangesAsync();

            string message;

            if (answer.is_correct)
            {
                message = QuizEnum.CORRECT_ANSWER;

            } else
            {
                message = QuizEnum.INCORRECT_ANSWER;
            }

            return new
            {
                message,
                data = new
                {
                    quiz_id = quiz.id,
                    quiz.question.question,
                    your_answer = answer.answer,
                    correct_answer = quiz.question.answers
                             .Where(answer => answer.is_correct == true)
                             .Select(answer => answer.answer).ToList()[0],
                    incorrect_answer = quiz.question.answers
                             .Where(answer => answer.is_correct == false)
                             .Select(answer => answer.answer).ToList(),
                }
            };
        }
    }
}
