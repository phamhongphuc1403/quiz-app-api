using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace quiz_app_api.src.Core.Database.Migrations
{
    /// <inheritdoc />
    public partial class init_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "id", "question" },
                values: new object[,]
                {
                    { 1, "What is the capital of France?" },
                    { 2, "What is the capital of Germany?" },
                    { 3, "What is the capital of Poland?" },
                    { 4, "What is the capital of Spain?" },
                    { 5, "What is the capital of Italy?" },
                    { 6, "What is the capital of Russia?" },
                    { 7, "What is the capital of Ukraine?" },
                    { 8, "What is the capital of Belarus?" },
                    { 9, "What is the capital of Czech Republic?" },
                    { 10, "What is the capital of Viet Nam?" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "password", "refresh_token", "username" },
                values: new object[,]
                {
                    { 1, "user1@example.com", "$2a$04$1CTs0YI.ufFf1l/CA1/Wa.8T/MqBxn/7FKKHmWjm80cnGsPNRosgS", "", "user1" },
                    { 2, "user2@example.com", "$2a$04$1CTs0YI.ufFf1l/CA1/Wa.8T/MqBxn/7FKKHmWjm80cnGsPNRosgS", "", "user2" },
                    { 3, "user3@example.com", "$2a$04$1CTs0YI.ufFf1l/CA1/Wa.8T/MqBxn/7FKKHmWjm80cnGsPNRosgS", "", "user3" }
                });

            migrationBuilder.InsertData(
                table: "answer",
                columns: new[] { "id", "answer", "is_correct", "question_id" },
                values: new object[,]
                {
                    { 1, "Paris", true, 1 },
                    { 2, "Berlin", false, 1 },
                    { 3, "Warsaw", false, 1 },
                    { 4, "Madrid", false, 1 },
                    { 5, "Paris", false, 2 },
                    { 6, "Berlin", true, 2 },
                    { 7, "Warsaw", false, 2 },
                    { 8, "Madrid", false, 2 },
                    { 9, "Paris", false, 3 },
                    { 10, "Berlin", false, 3 },
                    { 11, "Warsaw", true, 3 },
                    { 12, "Madrid", false, 3 },
                    { 13, "Paris", false, 4 },
                    { 14, "Berlin", false, 4 },
                    { 15, "Warsaw", false, 4 },
                    { 16, "Madrid", true, 4 },
                    { 17, "Paris", false, 5 },
                    { 18, "Berlin", false, 5 },
                    { 19, "Warsaw", false, 5 },
                    { 20, "Rome", true, 5 },
                    { 21, "Moscow", true, 6 },
                    { 22, "Berlin", false, 6 },
                    { 23, "Warsaw", false, 6 },
                    { 24, "Madrid", false, 6 },
                    { 25, "Paris", false, 7 },
                    { 26, "Berlin", false, 7 },
                    { 27, "Kiev", true, 7 },
                    { 28, "Madrid", false, 7 },
                    { 29, "Paris", false, 8 },
                    { 30, "Minsk", true, 8 },
                    { 31, "Warsaw", false, 8 },
                    { 32, "Madrid", false, 8 },
                    { 33, "Prague", true, 9 },
                    { 34, "Berlin", false, 9 },
                    { 35, "Warsaw", false, 9 },
                    { 36, "Madrid", false, 9 },
                    { 37, "Paris", false, 10 },
                    { 38, "Berlin", false, 10 },
                    { 39, "Warsaw", false, 10 },
                    { 40, "Ha Noi", true, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "answer",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "questions",
                keyColumn: "id",
                keyValue: 10);
        }
    }
}
