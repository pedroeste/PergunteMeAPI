using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class RemoveAlternative : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Alternative_alternativeId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "Alternative");

            migrationBuilder.DropIndex(
                name: "IX_Question_alternativeId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "alternativeId",
                table: "Question");

            migrationBuilder.AddColumn<string>(
                name: "alternative1",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "alternative2",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "alternative3",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "alternative4",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "alternative5",
                table: "Question",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alternative1",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "alternative2",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "alternative3",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "alternative4",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "alternative5",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "alternativeId",
                table: "Question",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Alternative",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    alternative1 = table.Column<string>(nullable: true),
                    alternative2 = table.Column<string>(nullable: true),
                    alternative3 = table.Column<string>(nullable: true),
                    alternative4 = table.Column<string>(nullable: true),
                    alternative5 = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternative", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_alternativeId",
                table: "Question",
                column: "alternativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Alternative_alternativeId",
                table: "Question",
                column: "alternativeId",
                principalTable: "Alternative",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
