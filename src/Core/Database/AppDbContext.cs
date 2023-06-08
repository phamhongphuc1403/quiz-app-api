using Microsoft.EntityFrameworkCore;
using quiz_app_api.src.Core.Database.Model;
using quiz_app_api.src.Core.Database.Models;

namespace quiz_app_api.src.Core.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<UserQuestionModel> UsersQuestions { get; set; }
        public virtual DbSet<QuestionModel> Questions { get; set; }
        public virtual DbSet<AnswerModel> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserQuestionModel>()
                .HasKey(e => new { e.question_id, e.user_id, e.take });

            modelBuilder.Entity<UserQuestionModel>()
                .HasOne(uq => uq.user)
                .WithMany(u => u.users_questions)
                .HasForeignKey(uq => uq.user_id);

            modelBuilder.Entity<UserQuestionModel>()
                .HasOne(uq => uq.question)
                .WithMany(q => q.users_questions)
                .HasForeignKey(uq => uq.question_id);

            modelBuilder.Entity<AnswerModel>()
                .HasOne(a => a.question)
                .WithMany(q => q.answers)
                .HasForeignKey(uq => uq.question_id);
        }
    }
}
