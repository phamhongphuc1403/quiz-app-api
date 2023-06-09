using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quiz_app_api.src.Core.Database.Migrations
{
    /// <inheritdoc />
    public partial class remove_user_id_primary_key_in_quizzes_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_quizzes",
                table: "quizzes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_quizzes",
                table: "quizzes",
                columns: new[] { "question_id", "id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_quizzes",
                table: "quizzes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_quizzes",
                table: "quizzes",
                columns: new[] { "question_id", "user_id", "id" });
        }
    }
}
