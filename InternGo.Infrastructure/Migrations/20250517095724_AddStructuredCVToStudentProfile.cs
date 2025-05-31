using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStructuredCVToStudentProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CVText",
                table: "student_profiles",
                newName: "Skills");

            migrationBuilder.AddColumn<string>(
                name: "CoverLetter",
                table: "student_profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "student_profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProgrammingLanguages",
                table: "student_profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverLetter",
                table: "student_profiles");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "student_profiles");

            migrationBuilder.DropColumn(
                name: "ProgrammingLanguages",
                table: "student_profiles");

            migrationBuilder.RenameColumn(
                name: "Skills",
                table: "student_profiles",
                newName: "CVText");
        }
    }
}
