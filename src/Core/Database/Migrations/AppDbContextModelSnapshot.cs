﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using quiz_app_api.src.Core.Database;

#nullable disable

namespace quiz_app_api.src.Core.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("quiz_app_api.src.Core.Database.Model.UserModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("refresh_token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            id = 1,
                            email = "user1@example.com",
                            password = "$2a$04$1CTs0YI.ufFf1l/CA1/Wa.8T/MqBxn/7FKKHmWjm80cnGsPNRosgS",
                            refresh_token = "",
                            username = "user1"
                        },
                        new
                        {
                            id = 2,
                            email = "user2@example.com",
                            password = "$2a$04$1CTs0YI.ufFf1l/CA1/Wa.8T/MqBxn/7FKKHmWjm80cnGsPNRosgS",
                            refresh_token = "",
                            username = "user2"
                        },
                        new
                        {
                            id = 3,
                            email = "user3@example.com",
                            password = "$2a$04$1CTs0YI.ufFf1l/CA1/Wa.8T/MqBxn/7FKKHmWjm80cnGsPNRosgS",
                            refresh_token = "",
                            username = "user3"
                        });
                });

            modelBuilder.Entity("quiz_app_api.src.Core.Database.Models.AnswerModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_correct")
                        .HasColumnType("bit");

                    b.Property<int>("question_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("question_id");

                    b.ToTable("answer");

                    b.HasData(
                        new
                        {
                            id = 1,
                            answer = "Paris",
                            is_correct = true,
                            question_id = 1
                        },
                        new
                        {
                            id = 2,
                            answer = "Berlin",
                            is_correct = false,
                            question_id = 1
                        },
                        new
                        {
                            id = 3,
                            answer = "Warsaw",
                            is_correct = false,
                            question_id = 1
                        },
                        new
                        {
                            id = 4,
                            answer = "Madrid",
                            is_correct = false,
                            question_id = 1
                        },
                        new
                        {
                            id = 5,
                            answer = "Paris",
                            is_correct = false,
                            question_id = 2
                        },
                        new
                        {
                            id = 6,
                            answer = "Berlin",
                            is_correct = true,
                            question_id = 2
                        },
                        new
                        {
                            id = 7,
                            answer = "Warsaw",
                            is_correct = false,
                            question_id = 2
                        },
                        new
                        {
                            id = 8,
                            answer = "Madrid",
                            is_correct = false,
                            question_id = 2
                        },
                        new
                        {
                            id = 9,
                            answer = "Paris",
                            is_correct = false,
                            question_id = 3
                        },
                        new
                        {
                            id = 10,
                            answer = "Berlin",
                            is_correct = false,
                            question_id = 3
                        },
                        new
                        {
                            id = 11,
                            answer = "Warsaw",
                            is_correct = true,
                            question_id = 3
                        },
                        new
                        {
                            id = 12,
                            answer = "Madrid",
                            is_correct = false,
                            question_id = 3
                        },
                        new
                        {
                            id = 13,
                            answer = "Paris",
                            is_correct = false,
                            question_id = 4
                        },
                        new
                        {
                            id = 14,
                            answer = "Berlin",
                            is_correct = false,
                            question_id = 4
                        },
                        new
                        {
                            id = 15,
                            answer = "Warsaw",
                            is_correct = false,
                            question_id = 4
                        },
                        new
                        {
                            id = 16,
                            answer = "Madrid",
                            is_correct = true,
                            question_id = 4
                        },
                        new
                        {
                            id = 17,
                            answer = "Paris",
                            is_correct = false,
                            question_id = 5
                        },
                        new
                        {
                            id = 18,
                            answer = "Berlin",
                            is_correct = false,
                            question_id = 5
                        },
                        new
                        {
                            id = 19,
                            answer = "Warsaw",
                            is_correct = false,
                            question_id = 5
                        },
                        new
                        {
                            id = 20,
                            answer = "Rome",
                            is_correct = true,
                            question_id = 5
                        },
                        new
                        {
                            id = 21,
                            answer = "Moscow",
                            is_correct = true,
                            question_id = 6
                        },
                        new
                        {
                            id = 22,
                            answer = "Berlin",
                            is_correct = false,
                            question_id = 6
                        },
                        new
                        {
                            id = 23,
                            answer = "Warsaw",
                            is_correct = false,
                            question_id = 6
                        },
                        new
                        {
                            id = 24,
                            answer = "Madrid",
                            is_correct = false,
                            question_id = 6
                        },
                        new
                        {
                            id = 25,
                            answer = "Paris",
                            is_correct = false,
                            question_id = 7
                        },
                        new
                        {
                            id = 26,
                            answer = "Berlin",
                            is_correct = false,
                            question_id = 7
                        },
                        new
                        {
                            id = 27,
                            answer = "Kiev",
                            is_correct = true,
                            question_id = 7
                        },
                        new
                        {
                            id = 28,
                            answer = "Madrid",
                            is_correct = false,
                            question_id = 7
                        },
                        new
                        {
                            id = 29,
                            answer = "Paris",
                            is_correct = false,
                            question_id = 8
                        },
                        new
                        {
                            id = 30,
                            answer = "Minsk",
                            is_correct = true,
                            question_id = 8
                        },
                        new
                        {
                            id = 31,
                            answer = "Warsaw",
                            is_correct = false,
                            question_id = 8
                        },
                        new
                        {
                            id = 32,
                            answer = "Madrid",
                            is_correct = false,
                            question_id = 8
                        },
                        new
                        {
                            id = 33,
                            answer = "Prague",
                            is_correct = true,
                            question_id = 9
                        },
                        new
                        {
                            id = 34,
                            answer = "Berlin",
                            is_correct = false,
                            question_id = 9
                        },
                        new
                        {
                            id = 35,
                            answer = "Warsaw",
                            is_correct = false,
                            question_id = 9
                        },
                        new
                        {
                            id = 36,
                            answer = "Madrid",
                            is_correct = false,
                            question_id = 9
                        },
                        new
                        {
                            id = 37,
                            answer = "Paris",
                            is_correct = false,
                            question_id = 10
                        },
                        new
                        {
                            id = 38,
                            answer = "Berlin",
                            is_correct = false,
                            question_id = 10
                        },
                        new
                        {
                            id = 39,
                            answer = "Warsaw",
                            is_correct = false,
                            question_id = 10
                        },
                        new
                        {
                            id = 40,
                            answer = "Ha Noi",
                            is_correct = true,
                            question_id = 10
                        });
                });

            modelBuilder.Entity("quiz_app_api.src.Core.Database.Models.QuestionModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("questions");

                    b.HasData(
                        new
                        {
                            id = 1,
                            question = "What is the capital of France?"
                        },
                        new
                        {
                            id = 2,
                            question = "What is the capital of Germany?"
                        },
                        new
                        {
                            id = 3,
                            question = "What is the capital of Poland?"
                        },
                        new
                        {
                            id = 4,
                            question = "What is the capital of Spain?"
                        },
                        new
                        {
                            id = 5,
                            question = "What is the capital of Italy?"
                        },
                        new
                        {
                            id = 6,
                            question = "What is the capital of Russia?"
                        },
                        new
                        {
                            id = 7,
                            question = "What is the capital of Ukraine?"
                        },
                        new
                        {
                            id = 8,
                            question = "What is the capital of Belarus?"
                        },
                        new
                        {
                            id = 9,
                            question = "What is the capital of Czech Republic?"
                        },
                        new
                        {
                            id = 10,
                            question = "What is the capital of Viet Nam?"
                        });
                });

            modelBuilder.Entity("quiz_app_api.src.Core.Database.Models.UserQuestionModel", b =>
                {
                    b.Property<int>("question_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.Property<int>("take")
                        .HasColumnType("int");

                    b.Property<int?>("answer")
                        .HasColumnType("int");

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<double>("time_to_answer")
                        .HasColumnType("float");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("question_id", "user_id", "take");

                    b.HasIndex("user_id");

                    b.ToTable("users_questions");
                });

            modelBuilder.Entity("quiz_app_api.src.Core.Database.Models.AnswerModel", b =>
                {
                    b.HasOne("quiz_app_api.src.Core.Database.Models.QuestionModel", "question")
                        .WithMany("answers")
                        .HasForeignKey("question_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("question");
                });

            modelBuilder.Entity("quiz_app_api.src.Core.Database.Models.UserQuestionModel", b =>
                {
                    b.HasOne("quiz_app_api.src.Core.Database.Models.QuestionModel", "question")
                        .WithMany("users_questions")
                        .HasForeignKey("question_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("quiz_app_api.src.Core.Database.Model.UserModel", "user")
                        .WithMany("users_questions")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("question");

                    b.Navigation("user");
                });

            modelBuilder.Entity("quiz_app_api.src.Core.Database.Model.UserModel", b =>
                {
                    b.Navigation("users_questions");
                });

            modelBuilder.Entity("quiz_app_api.src.Core.Database.Models.QuestionModel", b =>
                {
                    b.Navigation("answers");

                    b.Navigation("users_questions");
                });
#pragma warning restore 612, 618
        }
    }
}
