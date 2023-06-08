using Microsoft.EntityFrameworkCore;
using quiz_app_api.src.Core.Database.Model;
using quiz_app_api.src.Core.Database.Models;

namespace quiz_app_api.src.Core.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<QuizModel> Quizzes { get; set; }
        public virtual DbSet<QuestionModel> Questions { get; set; }
        public virtual DbSet<AnswerModel> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuizModel>()
                .HasKey(e => new { e.question_id, e.user_id, e.id });

            modelBuilder.Entity<QuizModel>()
                .HasOne(t => t.user)
                .WithMany(u => u.quizzes)
                .HasForeignKey(uq => uq.user_id);

            modelBuilder.Entity<QuizModel>()
                .HasOne(t => t.question)
                .WithMany(q => q.quizzes)
                .HasForeignKey(uq => uq.question_id);

            modelBuilder.Entity<AnswerModel>()
                .HasOne(a => a.question)
                .WithMany(q => q.answers)
                .HasForeignKey(uq => uq.question_id);

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel[]
                {
                    new UserModel
                    {
                        id = 1,
                        username = "user1",
                        email = "user1@example.com",
                        password = "$2a$04$1CTs0YI.ufFf1l/CA1/Wa.8T/MqBxn/7FKKHmWjm80cnGsPNRosgS"
                    },
                    new UserModel
                    {
                        id = 2,
                        username = "user2",
                        email = "user2@example.com",
                        password = "$2a$04$1CTs0YI.ufFf1l/CA1/Wa.8T/MqBxn/7FKKHmWjm80cnGsPNRosgS"
                    },
                    new UserModel
                    {
                         id = 3,
                        username = "user3",
                        email = "user3@example.com",
                        password = "$2a$04$1CTs0YI.ufFf1l/CA1/Wa.8T/MqBxn/7FKKHmWjm80cnGsPNRosgS"
                    },
                });

            modelBuilder.Entity<QuestionModel>().HasData(
                new QuestionModel[]
                {
                    new QuestionModel
                    {
                        id = 1,
                        question = "What is the capital of France?",
                    },
                    new QuestionModel
                    {
                        id = 2,
                        question = "What is the capital of Germany?",
                    },
                    new QuestionModel
                    {
                        id = 3,
                        question = "What is the capital of Poland?",
                    },
                    new QuestionModel
                    {
                        id = 4,
                        question = "What is the capital of Spain?",
                    },
                    new QuestionModel
                    {
                        id = 5,
                        question = "What is the capital of Italy?",
                    },
                    new QuestionModel
                    {
                        id = 6,
                        question = "What is the capital of Russia?",
                    },
                    new QuestionModel
                    {
                        id = 7,
                        question = "What is the capital of Ukraine?",
                    },
                    new QuestionModel
                    {
                        id = 8,
                        question = "What is the capital of Belarus?",
                    },
                    new QuestionModel
                    {
                        id = 9,
                        question = "What is the capital of Czech Republic?",
                    },
                    new QuestionModel
                    {
                        id = 10,
                        question = "What is the capital of Viet Nam?",
                    }
                });

            modelBuilder.Entity<AnswerModel>().HasData(
                new AnswerModel[]
                {
                    new AnswerModel
                    {
                        id = 1,
                        question_id = 1,
                        answer = "Paris",
                        is_correct = true
                    },
                    new AnswerModel
                    {
                        id = 2,
                        question_id = 1,
                        answer = "Berlin",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 3,
                        question_id = 1,
                        answer = "Warsaw",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 4,
                        question_id = 1,
                        answer = "Madrid",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 5,
                        question_id = 2,
                        answer = "Paris",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 6,
                        question_id = 2,
                        answer = "Berlin",
                        is_correct = true
                    },
                    new AnswerModel
                    {
                        id = 7,
                        question_id = 2,
                        answer = "Warsaw",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 8,
                        question_id = 2,
                        answer = "Madrid",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 9,
                        question_id = 3,
                        answer = "Paris",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 10,
                        question_id = 3,
                        answer = "Berlin",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 11,
                        question_id = 3,
                        answer = "Warsaw",
                        is_correct = true
                    },
                    new AnswerModel
                    {
                        id = 12,
                        question_id = 3,
                        answer = "Madrid",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 13,
                        question_id = 4,
                        answer = "Paris",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 14,
                        question_id = 4,
                        answer = "Berlin",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 15,
                        question_id = 4,
                        answer = "Warsaw",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 16,
                        question_id = 4,
                        answer = "Madrid",
                        is_correct = true
                    },
                    new AnswerModel
                    {
                        id = 17,
                        question_id = 5,
                        answer = "Paris",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 18,
                        question_id = 5,
                        answer = "Berlin",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 19,
                        question_id = 5,
                        answer = "Warsaw",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 20,
                        question_id = 5,
                        answer = "Rome",
                        is_correct = true
                    },
                    new AnswerModel
                    {
                        id = 21,
                        question_id = 6,
                        answer = "Moscow",
                        is_correct = true
                    },
                    new AnswerModel
                    {
                        id = 22,
                        question_id = 6,
                        answer = "Berlin",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 23,
                        question_id = 6,
                        answer = "Warsaw",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 24,
                        question_id = 6,
                        answer = "Madrid",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 25,
                        question_id = 7,
                        answer = "Paris",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 26,
                        question_id = 7,
                        answer = "Berlin",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 27,
                        question_id = 7,
                        answer = "Kiev",
                        is_correct = true
                    },
                    new AnswerModel
                    {
                        id = 28,
                        question_id = 7,
                        answer = "Madrid",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 29,
                        question_id = 8,
                        answer = "Paris",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 30,
                        question_id = 8,
                        answer = "Minsk",
                        is_correct = true
                    },
                    new AnswerModel
                    {
                        id = 31,
                        question_id = 8,
                        answer = "Warsaw",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 32,
                        question_id = 8,
                        answer = "Madrid",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 33,
                        question_id = 9,
                        answer = "Prague",
                        is_correct = true
                    },
                    new AnswerModel
                    {
                        id = 34,
                        question_id = 9,
                        answer = "Berlin",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 35,
                        question_id = 9,
                        answer = "Warsaw",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 36,
                        question_id = 9,
                        answer = "Madrid",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 37,
                        question_id = 10,
                        answer = "Paris",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 38,
                        question_id = 10,
                        answer = "Berlin",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 39,
                        question_id = 10,
                        answer = "Warsaw",
                        is_correct = false
                    },
                    new AnswerModel
                    {
                        id = 40,
                        question_id = 10,
                        answer = "Ha Noi",
                        is_correct = true
                    },
                });
        }
    }
}
