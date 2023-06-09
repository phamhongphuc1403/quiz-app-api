using quiz_app_api.src.Core.Database.Models;
using quiz_app_api.src.Core.Database;
using Microsoft.EntityFrameworkCore;
using quiz_app_api.src.Core.Enums;

namespace quiz_app_api.src.Core.Modules.Question
{
    public class QuestionRepository
    {
        private readonly AppDbContext _context;
        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<QuestionModel> GetQuestionList()
        {
            return _context.Questions
                .OrderBy(x => Guid.NewGuid())
                .Take(ScoreEnum.MAX_SCORE)
                .Include(q => q.answers)
                .ToList();
        }
        public QuizModel? GetQuestionByIdAndQuizIdAndUserId(int questionId, string quizId, int userId)
        {
            return _context.Quizzes
                .Include(quiz => quiz.question)
                .Include(quiz => quiz.question.answers)
                .FirstOrDefault(quiz => quiz.id == quizId && quiz.question_id == questionId && quiz.user_id == userId);
        }

        public AnswerModel? GetAnswerByIdAndQuestionid(int answerId, int questionId)
        {
            return _context.Answers.FirstOrDefault(answer => answer.id == answerId && answer.question_id == questionId);
        }
    }
}
