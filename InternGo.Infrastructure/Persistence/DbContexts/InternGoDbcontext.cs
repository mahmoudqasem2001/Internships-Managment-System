

using InternGo.Domain.Entities;
using InternGo.Domain.Enums;
using InternGo.Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InternGo.Infrastructure.Persistence.DbContexts
{
    public class InternGoDbContext(DbContextOptions<InternGoDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<InternshipApplication> Applications { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<AdminLog> AdminLogs { get; set; }
        public DbSet<AIRecommendation> AIRecommendations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StudentProfileConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyProfileConfiguration());
            modelBuilder.ApplyConfiguration(new InternshipConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new AdminLogConfiguration());
            modelBuilder.ApplyConfiguration(new AIRecommendationConfiguration());


           // var adminId = new Guid("3F2504E0-4F89-11D3-9A0C-0305E82C3301");
           // var adminCreatedAt = new DateTime(2024, 4, 26, 0, 0, 0, DateTimeKind.Utc);

           // // Pre-generated static password hash for "Admin@123"
           // var passwordHash = "AQAAAAIAAYagAAAAEPkjiCFIrYUNqIXBspWdaKHnrxGqaKkUXxlTkFf7MISzkAmqptzKT0Z0y6Vxt1vtcg==";

           // var admin = new User
           // {
           //     Id = adminId,
           //     FullName = "Super Admin",
           //     Email = "admin@internGo.com",
           //     Role = UserRole.Admin,
           //     IsActive = true,
           //     CreatedAt = adminCreatedAt,
           //     PasswordHash = passwordHash
           // };

           // var companyUser1Id = new Guid("c26c729d-e236-4b0e-90e8-8057f1f01a40");
           // var companyUser2Id = new Guid("fabfef3d-78bf-46d9-aeec-32a142101bea");
           // var companyUser3Id = new Guid("1c0cd8ff-6e48-45f2-8154-673a3be659b5");

           // // Pre-generated password hash for "Company@123"
           // var companyPasswordHash = "AQAAAAIAAYagAAAAED2OsyPCoFAnQL23xlhHPOsNRaK7U99QqJQH5qz6k45XsZFH7hAcmuCokZ3AQ8v9Ag==";

           // modelBuilder.Entity<User>().HasData(
           //     admin,
           //     new User
           //     {
           //         Id = companyUser1Id,
           //         FullName = "Tech Admin",
           //         Email = "tech@company.com",
           //         Role = UserRole.Company,
           //         IsActive = true,
           //         CreatedAt = new DateTime(2024, 04, 26),
           //         PasswordHash = companyPasswordHash
           //     },
           //     new User
           //     {
           //         Id = companyUser2Id,
           //         FullName = "AI Admin",
           //         Email = "ai@company.com",
           //         Role = UserRole.Company,
           //         IsActive = true,
           //         CreatedAt = new DateTime(2024, 04, 27),
           //         PasswordHash = companyPasswordHash
           //     },
           //     new User
           //     {
           //         Id = companyUser3Id,
           //         FullName = "Web Admin",
           //         Email = "web@company.com",
           //         Role = UserRole.Company,
           //         IsActive = true,
           //         CreatedAt = new DateTime(2024, 04, 28),
           //         PasswordHash = companyPasswordHash
           //     }
           //);



//            var internship1Id = new Guid("aaaa1111-1111-1111-1111-111111111111");
//            var internship2Id = new Guid("bbbb2222-2222-2222-2222-222222222222");
//            var internship3Id = new Guid("cccc3333-3333-3333-3333-333333333333");

//            modelBuilder.Entity<Internship>().HasData(
//                new Internship
//                {
//                    Id = internship1Id,
//                    CompanyProfileId = companyUser1Id,
//                    Title = "Backend Developer Intern",
//                    Description = "Work on ASP.NET APIs and SQL databases.",
//                    SkillsRequired = "dotnet, sql, teamwork",
//                    Capacity = 2,
//                    Deadline = new DateTime(2025, 6, 30)
//                },
//                new Internship
//                {
//                    Id = internship2Id,
//                    CompanyProfileId = companyUser2Id,
//                    Title = "AI Assistant Intern",
//                    Description = "Help build intelligent systems using Python.",
//                    SkillsRequired = "python, machinelearning, communication",
//                    Capacity = 1,
//                    Deadline = new DateTime(2025, 7, 15)
//                },
//                new Internship
//                {
//                    Id = internship3Id,
//                    CompanyProfileId = companyUser3Id,
//                    Title = "Frontend Developer Intern",
//                    Description = "Develop responsive UIs using JS/React.",
//                    SkillsRequired = "javascript, html, css",
//                    Capacity = 3,
//                    Deadline = new DateTime(2025, 6, 20)
//                }

//                );


//            modelBuilder.Entity<Review>().HasData(
//    new Review
//    {
//        Id = new Guid("c26c729d-e236-4b0e-90e8-8057f1f01a40"),
//        StudentProfileId = new Guid("758cdc94-41d5-40d1-8f86-8125bb90c326"),
//        InternshipId = internship1Id,
//        Comment = "Excellent mentorship and environment!",
//        Rating = 5,
//        PostedAt = new DateTime(2025, 05, 01)
//    }
//);

//            modelBuilder.Entity<InternshipApplication>().HasData(
//                new InternshipApplication
//                {
//                    Id = new Guid("fabfef3d-78bf-46d9-aeec-32a142101bea"),
//                    StudentProfileId = new Guid("758cdc94-41d5-40d1-8f86-8125bb90c326"),
//                    InternshipId = internship1Id,
//                    AppliedAt = new DateTime(2025, 05, 01),
//                    Status = "Pending"
//                }
//            );


            //modelBuilder.Entity<User>().HasData(admin);


            base.OnModelCreating(modelBuilder);

        }



    }

}
