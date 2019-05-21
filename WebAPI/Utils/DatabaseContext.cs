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

        public DbSet<UserModel> User { get; set; }
        public DbSet<SchoolModel> School { get; set; }
        public DbSet<CourseModel> Course { get; set; }
        public DbSet<SubjectModel> Subject { get; set; }
        public DbSet<QuestionModel> Question { get; set; }
        public DbSet<TestModel> Test { get; set; }
        public DbSet<UserSubjectModel> UserSubject { get; set; }
        public DbSet<CourseSubjectModel> CourseSubject { get; set; }
        public DbSet<TestQuestionModel> TestQuestion { get; set; }
    }
}
