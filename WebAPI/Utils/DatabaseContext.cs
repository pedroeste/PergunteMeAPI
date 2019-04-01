using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Utils
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<SchoolModel> SchoolModel { get; set; }
        public DbSet<CourseModel> CourseModel { get; set; }
        public DbSet<SubjectModel> SubjectModel { get; set; }
        public DbSet<QuestionModel> QuestionModel { get; set; }
        public DbSet<AlternativeModel> AlternativeModel { get; set; }
        public DbSet<TestModel> TestModel { get; set; }
        public DbSet<UserSubjectModel> UserSubject { get; set; }
        public DbSet<CourseSubjectModel> CourseSubject { get; set; }
        public DbSet<TestQuestionModel> TestQuestion { get; set; }
    }
}
