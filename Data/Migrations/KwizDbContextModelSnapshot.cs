﻿// <auto-generated />
using System;
using Kwiz.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace kwiz_backend.Data.Migrations
{
    [DbContext(typeof(KwizDbContext))]
    partial class KwizDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Kwiz.Api.Entities.QuestionOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("boolean");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubmissionId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SubmissionSelectionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SubmissionSelectionId");

                    b.ToTable("QuestionOptions");
                });

            modelBuilder.Entity("Kwiz.Api.Entities.Quiz", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ClosingDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OpeningDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("SubmissionId")
                        .HasColumnType("uuid");

                    b.Property<string[]>("Tags")
                        .HasColumnType("text[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("SubmissionId")
                        .IsUnique();

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("Kwiz.Api.Entities.QuizQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<Guid>("SubmissionSelectionId")
                        .HasColumnType("uuid");

                    b.Property<string[]>("Tags")
                        .HasColumnType("text[]");

                    b.Property<int>("TimeLimitSeconds")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubmissionSelectionId")
                        .IsUnique();

                    b.ToTable("QuizQuestions");
                });

            modelBuilder.Entity("Kwiz.Api.Entities.Submission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("FinishedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("Kwiz.Api.Entities.SubmissionSelection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsSkipped")
                        .HasColumnType("boolean");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SubmissionId")
                        .HasColumnType("uuid");

                    b.Property<int>("TimeSpentOnQuestion")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubmissionId");

                    b.ToTable("SubmissionSelections");
                });

            modelBuilder.Entity("Kwiz.Api.Entities.TechInterest", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string[]>("Interests")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UserId");

                    b.ToTable("TechInterests");
                });

            modelBuilder.Entity("Kwiz.Api.Entities.Technologies", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.HasKey("Id");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("QuizQuizQuestion", b =>
                {
                    b.Property<Guid>("QuestionsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuizzesId")
                        .HasColumnType("uuid");

                    b.HasKey("QuestionsId", "QuizzesId");

                    b.HasIndex("QuizzesId");

                    b.ToTable("QuizQuizQuestion", (string)null);
                });

            modelBuilder.Entity("Kwiz.Api.Entities.QuestionOption", b =>
                {
                    b.HasOne("Kwiz.Api.Entities.QuizQuestion", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kwiz.Api.Entities.SubmissionSelection", "SubmissionSelection")
                        .WithMany("SelectedOptions")
                        .HasForeignKey("SubmissionSelectionId");

                    b.Navigation("Question");

                    b.Navigation("SubmissionSelection");
                });

            modelBuilder.Entity("Kwiz.Api.Entities.Quiz", b =>
                {
                    b.HasOne("Kwiz.Api.Entities.Submission", "Submission")
                        .WithOne("Quiz")
                        .HasForeignKey("Kwiz.Api.Entities.Quiz", "SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("Kwiz.Api.Entities.QuizQuestion", b =>
                {
                    b.HasOne("Kwiz.Api.Entities.SubmissionSelection", "SubmissionSelection")
                        .WithOne("Question")
                        .HasForeignKey("Kwiz.Api.Entities.QuizQuestion", "SubmissionSelectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubmissionSelection");
                });

            modelBuilder.Entity("Kwiz.Api.Entities.SubmissionSelection", b =>
                {
                    b.HasOne("Kwiz.Api.Entities.Submission", null)
                        .WithMany("Selections")
                        .HasForeignKey("SubmissionId");
                });

            modelBuilder.Entity("QuizQuizQuestion", b =>
                {
                    b.HasOne("Kwiz.Api.Entities.QuizQuestion", null)
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kwiz.Api.Entities.Quiz", null)
                        .WithMany()
                        .HasForeignKey("QuizzesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kwiz.Api.Entities.QuizQuestion", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("Kwiz.Api.Entities.Submission", b =>
                {
                    b.Navigation("Quiz");

                    b.Navigation("Selections");
                });

            modelBuilder.Entity("Kwiz.Api.Entities.SubmissionSelection", b =>
                {
                    b.Navigation("Question");

                    b.Navigation("SelectedOptions");
                });
#pragma warning restore 612, 618
        }
    }
}
