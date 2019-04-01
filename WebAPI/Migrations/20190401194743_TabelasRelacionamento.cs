using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class TabelasRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlternativeModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    alternative1 = table.Column<string>(nullable: true),
                    alternative2 = table.Column<string>(nullable: true),
                    alternative3 = table.Column<string>(nullable: true),
                    alternative4 = table.Column<string>(nullable: true),
                    alternative5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativeModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TestModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    dueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cpf = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    isAdmin = table.Column<bool>(nullable: false),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CourseModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    subjectId = table.Column<int>(nullable: false),
                    schoolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_CourseModel_SchoolModel_schoolId",
                        column: x => x.schoolId,
                        principalTable: "SchoolModel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    imgUrl = table.Column<string>(nullable: true),
                    topic = table.Column<string>(nullable: true),
                    dificulty = table.Column<string>(nullable: true),
                    alternativeId = table.Column<int>(nullable: false),
                    subjectId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_QuestionModel_AlternativeModel_alternativeId",
                        column: x => x.alternativeId,
                        principalTable: "AlternativeModel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionModel_SubjectModel_subjectId",
                        column: x => x.subjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSubject",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(nullable: false),
                    subjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubject", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserSubject_SubjectModel_subjectId",
                        column: x => x.subjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSubject_UserModel_userId",
                        column: x => x.userId,
                        principalTable: "UserModel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSubject",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    courseId = table.Column<int>(nullable: false),
                    subjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubject", x => x.id);
                    table.ForeignKey(
                        name: "FK_CourseSubject_CourseModel_courseId",
                        column: x => x.courseId,
                        principalTable: "CourseModel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSubject_SubjectModel_subjectId",
                        column: x => x.subjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestQuestion",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    testId = table.Column<int>(nullable: false),
                    questionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestion", x => x.id);
                    table.ForeignKey(
                        name: "FK_TestQuestion_QuestionModel_questionId",
                        column: x => x.questionId,
                        principalTable: "QuestionModel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestQuestion_TestModel_testId",
                        column: x => x.testId,
                        principalTable: "TestModel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseModel_schoolId",
                table: "CourseModel",
                column: "schoolId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubject_courseId",
                table: "CourseSubject",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubject_subjectId",
                table: "CourseSubject",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionModel_alternativeId",
                table: "QuestionModel",
                column: "alternativeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionModel_subjectId",
                table: "QuestionModel",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestion_questionId",
                table: "TestQuestion",
                column: "questionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestion_testId",
                table: "TestQuestion",
                column: "testId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubject_subjectId",
                table: "UserSubject",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubject_userId",
                table: "UserSubject",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSubject");

            migrationBuilder.DropTable(
                name: "TestQuestion");

            migrationBuilder.DropTable(
                name: "UserSubject");

            migrationBuilder.DropTable(
                name: "CourseModel");

            migrationBuilder.DropTable(
                name: "QuestionModel");

            migrationBuilder.DropTable(
                name: "TestModel");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "SchoolModel");

            migrationBuilder.DropTable(
                name: "AlternativeModel");

            migrationBuilder.DropTable(
                name: "SubjectModel");
        }
    }
}
