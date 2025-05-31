using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InternGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "applications",
                keyColumn: "Id",
                keyValue: new Guid("fabfef3d-78bf-46d9-aeec-32a142101bea"));

            migrationBuilder.DeleteData(
                table: "internships",
                keyColumn: "Id",
                keyValue: new Guid("bbbb2222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "internships",
                keyColumn: "Id",
                keyValue: new Guid("cccc3333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "reviews",
                keyColumn: "Id",
                keyValue: new Guid("c26c729d-e236-4b0e-90e8-8057f1f01a40"));

            migrationBuilder.DeleteData(
                table: "company_profiles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "company_profiles",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "internships",
                keyColumn: "Id",
                keyValue: new Guid("aaaa1111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "company_profiles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { new Guid("1c0cd8ff-6e48-45f2-8154-673a3be659b5"), new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "web@company.com", "Web Admin", true, "AQAAAAIAAYagAAAAED2OsyPCoFAnQL23xlhHPOsNRaK7U99QqJQH5qz6k45XsZFH7hAcmuCokZ3AQ8v9Ag==", "Company" },
                    { new Guid("c26c729d-e236-4b0e-90e8-8057f1f01a40"), new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "tech@company.com", "Tech Admin", true, "AQAAAAIAAYagAAAAED2OsyPCoFAnQL23xlhHPOsNRaK7U99QqJQH5qz6k45XsZFH7hAcmuCokZ3AQ8v9Ag==", "Company" },
                    { new Guid("fabfef3d-78bf-46d9-aeec-32a142101bea"), new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "ai@company.com", "AI Admin", true, "AQAAAAIAAYagAAAAED2OsyPCoFAnQL23xlhHPOsNRaK7U99QqJQH5qz6k45XsZFH7hAcmuCokZ3AQ8v9Ag==", "Company" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("1c0cd8ff-6e48-45f2-8154-673a3be659b5"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("c26c729d-e236-4b0e-90e8-8057f1f01a40"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("fabfef3d-78bf-46d9-aeec-32a142101bea"));

            migrationBuilder.InsertData(
                table: "company_profiles",
                columns: new[] { "Id", "CompanyName", "Location", "MaxTrainees", "UserId", "Website", "WorkingHours" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Tech Innovators", "Ramallah", 5, new Guid("c26c729d-e236-4b0e-90e8-8057f1f01a40"), "https://techinnovators.com", "Mon-Fri, 9am-5pm" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "AI Solutions", "Nablus", 3, new Guid("fabfef3d-78bf-46d9-aeec-32a142101bea"), "https://aisolutions.com", "Sun-Thu, 8am-4pm" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Web Builders", "Jenin", 4, new Guid("1c0cd8ff-6e48-45f2-8154-673a3be659b5"), "https://webbuilders.com", "Flexible (Remote)" }
                });

            migrationBuilder.InsertData(
                table: "internships",
                columns: new[] { "Id", "Capacity", "CompanyProfileId", "Deadline", "Description", "SkillsRequired", "Title" },
                values: new object[,]
                {
                    { new Guid("aaaa1111-1111-1111-1111-111111111111"), 2, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Work on ASP.NET APIs and SQL databases.", "dotnet, sql, teamwork", "Backend Developer Intern" },
                    { new Guid("bbbb2222-2222-2222-2222-222222222222"), 1, new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Help build intelligent systems using Python.", "python, machinelearning, communication", "AI Assistant Intern" },
                    { new Guid("cccc3333-3333-3333-3333-333333333333"), 3, new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Develop responsive UIs using JS/React.", "javascript, html, css", "Frontend Developer Intern" }
                });

            migrationBuilder.InsertData(
                table: "applications",
                columns: new[] { "Id", "AppliedAt", "InternshipId", "Status", "StudentProfileId" },
                values: new object[] { new Guid("fabfef3d-78bf-46d9-aeec-32a142101bea"), new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aaaa1111-1111-1111-1111-111111111111"), "Pending", new Guid("758cdc94-41d5-40d1-8f86-8125bb90c326") });

            migrationBuilder.InsertData(
                table: "reviews",
                columns: new[] { "Id", "Comment", "InternshipId", "PostedAt", "Rating", "StudentProfileId" },
                values: new object[] { new Guid("c26c729d-e236-4b0e-90e8-8057f1f01a40"), "Excellent mentorship and environment!", new Guid("aaaa1111-1111-1111-1111-111111111111"), new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new Guid("758cdc94-41d5-40d1-8f86-8125bb90c326") });
        }
    }
}
