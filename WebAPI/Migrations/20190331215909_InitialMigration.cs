using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class InitialMigration : Migration
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
                    cpf = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    isAdmin = table.Column<bool>(nullable: false),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.cpf);
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
                    TestModelid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_QuestionModel_TestModel_TestModelid",
                        column: x => x.TestModelid,
                        principalTable: "TestModel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionModel_AlternativeModel_alternativeId",
                        column: x => x.alternativeId,
                        principalTable: "AlternativeModel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    courseId = table.Column<int>(nullable: false),
                    UserModelcpf = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_SubjectModel_UserModel_UserModelcpf",
                        column: x => x.UserModelcpf,
                        principalTable: "UserModel",
                        principalColumn: "cpf",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_CourseModel_SubjectModel_subjectId",
                        column: x => x.subjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseModel_schoolId",
                table: "CourseModel",
                column: "schoolId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseModel_subjectId",
                table: "CourseModel",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionModel_TestModelid",
                table: "QuestionModel",
                column: "TestModelid");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionModel_alternativeId",
                table: "QuestionModel",
                column: "alternativeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectModel_UserModelcpf",
                table: "SubjectModel",
                column: "UserModelcpf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseModel");

            migrationBuilder.DropTable(
                name: "QuestionModel");

            migrationBuilder.DropTable(
                name: "SchoolModel");

            migrationBuilder.DropTable(
                name: "SubjectModel");

            migrationBuilder.DropTable(
                name: "TestModel");

            migrationBuilder.DropTable(
                name: "AlternativeModel");

            migrationBuilder.DropTable(
                name: "UserModel");
        }
    }
}
