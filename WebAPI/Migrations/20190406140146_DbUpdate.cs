using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class DbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseModel_SchoolModel_schoolId",
                table: "CourseModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubject_CourseModel_courseId",
                table: "CourseSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubject_SubjectModel_subjectId",
                table: "CourseSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionModel_AlternativeModel_alternativeId",
                table: "QuestionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionModel_SubjectModel_subjectId",
                table: "QuestionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_QuestionModel_questionId",
                table: "TestQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_TestModel_testId",
                table: "TestQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubject_SubjectModel_subjectId",
                table: "UserSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubject_UserModel_userId",
                table: "UserSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserModel",
                table: "UserModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestModel",
                table: "TestModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectModel",
                table: "SubjectModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolModel",
                table: "SchoolModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionModel",
                table: "QuestionModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseModel",
                table: "CourseModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlternativeModel",
                table: "AlternativeModel");

            migrationBuilder.RenameTable(
                name: "UserModel",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "TestModel",
                newName: "Test");

            migrationBuilder.RenameTable(
                name: "SubjectModel",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "SchoolModel",
                newName: "School");

            migrationBuilder.RenameTable(
                name: "QuestionModel",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "CourseModel",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "AlternativeModel",
                newName: "Alternative");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionModel_subjectId",
                table: "Question",
                newName: "IX_Question_subjectId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionModel_alternativeId",
                table: "Question",
                newName: "IX_Question_alternativeId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseModel_schoolId",
                table: "Course",
                newName: "IX_Course_schoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Test",
                table: "Test",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_School",
                table: "School",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alternative",
                table: "Alternative",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_School_schoolId",
                table: "Course",
                column: "schoolId",
                principalTable: "School",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubject_Course_courseId",
                table: "CourseSubject",
                column: "courseId",
                principalTable: "Course",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubject_Subject_subjectId",
                table: "CourseSubject",
                column: "subjectId",
                principalTable: "Subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Alternative_alternativeId",
                table: "Question",
                column: "alternativeId",
                principalTable: "Alternative",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Subject_subjectId",
                table: "Question",
                column: "subjectId",
                principalTable: "Subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_Question_questionId",
                table: "TestQuestion",
                column: "questionId",
                principalTable: "Question",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_Test_testId",
                table: "TestQuestion",
                column: "testId",
                principalTable: "Test",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubject_Subject_subjectId",
                table: "UserSubject",
                column: "subjectId",
                principalTable: "Subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubject_User_userId",
                table: "UserSubject",
                column: "userId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_School_schoolId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubject_Course_courseId",
                table: "CourseSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSubject_Subject_subjectId",
                table: "CourseSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Alternative_alternativeId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Subject_subjectId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_Question_questionId",
                table: "TestQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_Test_testId",
                table: "TestQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubject_Subject_subjectId",
                table: "UserSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubject_User_userId",
                table: "UserSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Test",
                table: "Test");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School",
                table: "School");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alternative",
                table: "Alternative");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "UserModel");

            migrationBuilder.RenameTable(
                name: "Test",
                newName: "TestModel");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "SubjectModel");

            migrationBuilder.RenameTable(
                name: "School",
                newName: "SchoolModel");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "QuestionModel");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "CourseModel");

            migrationBuilder.RenameTable(
                name: "Alternative",
                newName: "AlternativeModel");

            migrationBuilder.RenameIndex(
                name: "IX_Question_subjectId",
                table: "QuestionModel",
                newName: "IX_QuestionModel_subjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_alternativeId",
                table: "QuestionModel",
                newName: "IX_QuestionModel_alternativeId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_schoolId",
                table: "CourseModel",
                newName: "IX_CourseModel_schoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserModel",
                table: "UserModel",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestModel",
                table: "TestModel",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectModel",
                table: "SubjectModel",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolModel",
                table: "SchoolModel",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionModel",
                table: "QuestionModel",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseModel",
                table: "CourseModel",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlternativeModel",
                table: "AlternativeModel",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseModel_SchoolModel_schoolId",
                table: "CourseModel",
                column: "schoolId",
                principalTable: "SchoolModel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubject_CourseModel_courseId",
                table: "CourseSubject",
                column: "courseId",
                principalTable: "CourseModel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSubject_SubjectModel_subjectId",
                table: "CourseSubject",
                column: "subjectId",
                principalTable: "SubjectModel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionModel_AlternativeModel_alternativeId",
                table: "QuestionModel",
                column: "alternativeId",
                principalTable: "AlternativeModel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionModel_SubjectModel_subjectId",
                table: "QuestionModel",
                column: "subjectId",
                principalTable: "SubjectModel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_QuestionModel_questionId",
                table: "TestQuestion",
                column: "questionId",
                principalTable: "QuestionModel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_TestModel_testId",
                table: "TestQuestion",
                column: "testId",
                principalTable: "TestModel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubject_SubjectModel_subjectId",
                table: "UserSubject",
                column: "subjectId",
                principalTable: "SubjectModel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubject_UserModel_userId",
                table: "UserSubject",
                column: "userId",
                principalTable: "UserModel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
