using quiz_app_api.src.Core.Database.Models;
using quiz_app_api.src.Core.Database;
using Microsoft.EntityFrameworkCore;

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
                .Take(5)
                .Include(q => q.answers)
                .ToList();
        }
    }
}
