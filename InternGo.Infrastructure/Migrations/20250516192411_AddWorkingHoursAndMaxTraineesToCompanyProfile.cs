using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkingHoursAndMaxTraineesToCompanyProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxTrainees",
                table: "company_profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WorkingHours",
                table: "company_profiles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxTrainees",
                table: "company_profiles");

            migrationBuilder.DropColumn(
                name: "WorkingHours",
                table: "company_profiles");
        }
    }
}
