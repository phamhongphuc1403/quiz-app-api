﻿using Microsoft.EntityFrameworkCore;
using quiz_app_api.src.Core.Database;
using quiz_app_api.src.Core.Database.Models;
using quiz_app_api.src.Packages.HttpExceptions;

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
            try
            {
                _context.Quizzes.AddRange(quizzes);

                await SaveChangesAsync();

                return quizzes;
            } catch (Exception ex)
            {
                throw new InternalException(ex.Message);
            }
        }
        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new InternalException(ex.Message);
            }
        }
        public List<QuizModel> GetQuizListsByUserId(int userId)
        {
            try
            {
                return _context.Quizzes
                    .OrderByDescending(q => q.created_at)
                    .Where(q => q.user_id == userId)
                    .Include(q => q.question).ThenInclude(q => q.answers)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new InternalException(ex.Message);
            }
        }

        public List<QuizModel> GetQuizListByIdAndUserId(string quizId, int userId)
        {
            try
            {
                return _context.Quizzes
                    .OrderByDescending(q => q.created_at)
                    .Where(q => q.user_id == userId && q.id == quizId)
                    .Include(q => q.question).ThenInclude(q => q.answers)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new InternalException(ex.Message);
            }
        }
    }
}
