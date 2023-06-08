using quiz_app_api.src.Core.Database;
using quiz_app_api.src.Core.Database.Models;

namespace quiz_app_api.src.Core.Modules.Quiz
{
    public class QuizRepository
    {
        private readonly AppDbContext _context;
        public QuizRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<QuizModel>> CreateQuiz(List<QuizModel> quizzes)
        {
            _context.Quizzes.AddRange(quizzes);

            await _context.SaveChangesAsync();

            return quizzes;
        }
    }
}
