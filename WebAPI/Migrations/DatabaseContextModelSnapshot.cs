﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Utils;

namespace WebAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.AlternativeModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("alternative1");

                    b.Property<string>("alternative2");

                    b.Property<string>("alternative3");

                    b.Property<string>("alternative4");

                    b.Property<string>("alternative5");

                    b.Property<bool>("isActive");

                    b.HasKey("id");

                    b.ToTable("Alternative");
                });

            modelBuilder.Entity("WebAPI.Models.CourseModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("isActive");

                    b.Property<string>("name");

                    b.Property<int>("schoolId");

                    b.HasKey("id");

                    b.HasIndex("schoolId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("WebAPI.Models.CourseSubjectModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("courseId");

                    b.Property<int>("subjectId");

                    b.HasKey("id");

                    b.HasIndex("courseId");

                    b.HasIndex("subjectId");

                    b.ToTable("CourseSubject");
                });

            modelBuilder.Entity("WebAPI.Models.QuestionModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("alternativeId");

                    b.Property<string>("dificulty");

                    b.Property<string>("imgUrl");

                    b.Property<bool>("isActive");

                    b.Property<string>("question");

                    b.Property<int>("subjectId");

                    b.Property<string>("topic");

                    b.HasKey("id");

                    b.HasIndex("alternativeId");

                    b.HasIndex("subjectId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("WebAPI.Models.SchoolModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<bool>("isActive");

                    b.HasKey("id");

                    b.ToTable("School");
                });

            modelBuilder.Entity("WebAPI.Models.SubjectModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("isActive");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("WebAPI.Models.TestModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dueDate");

                    b.Property<bool>("isActive");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("WebAPI.Models.TestQuestionModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("questionId");

                    b.Property<int>("testId");

                    b.HasKey("id");

                    b.HasIndex("questionId");

                    b.HasIndex("testId");

                    b.ToTable("TestQuestion");
                });

            modelBuilder.Entity("WebAPI.Models.UserModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cpf");

                    b.Property<string>("email");

                    b.Property<bool>("isActive");

                    b.Property<bool>("isAdmin");

                    b.Property<string>("name");

                    b.Property<string>("phone");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebAPI.Models.UserSubjectModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("subjectId");

                    b.Property<int>("userId");

                    b.HasKey("id");

                    b.HasIndex("subjectId");

                    b.HasIndex("userId");

                    b.ToTable("UserSubject");
                });

            modelBuilder.Entity("WebAPI.Models.CourseModel", b =>
                {
                    b.HasOne("WebAPI.Models.SchoolModel", "School")
                        .WithMany()
                        .HasForeignKey("schoolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPI.Models.CourseSubjectModel", b =>
                {
                    b.HasOne("WebAPI.Models.CourseModel", "Course")
                        .WithMany()
                        .HasForeignKey("courseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAPI.Models.SubjectModel", "Subject")
                        .WithMany()
                        .HasForeignKey("subjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPI.Models.QuestionModel", b =>
                {
                    b.HasOne("WebAPI.Models.AlternativeModel", "Alternative")
                        .WithMany()
                        .HasForeignKey("alternativeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAPI.Models.SubjectModel", "Subject")
                        .WithMany()
                        .HasForeignKey("subjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPI.Models.TestQuestionModel", b =>
                {
                    b.HasOne("WebAPI.Models.QuestionModel", "Question")
                        .WithMany()
                        .HasForeignKey("questionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAPI.Models.TestModel", "Test")
                        .WithMany()
                        .HasForeignKey("testId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPI.Models.UserSubjectModel", b =>
                {
                    b.HasOne("WebAPI.Models.SubjectModel", "Subject")
                        .WithMany()
                        .HasForeignKey("subjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAPI.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
