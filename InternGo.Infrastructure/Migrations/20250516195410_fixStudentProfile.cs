using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixStudentProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "student_profiles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreferredLocation",
                table: "student_profiles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "student_profiles");

            migrationBuilder.DropColumn(
                name: "PreferredLocation",
                table: "student_profiles");
        }
    }
}
