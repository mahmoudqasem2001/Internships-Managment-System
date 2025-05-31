using InternGo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternGo.Infrastructure.Persistence.Configurations
{
    public class StudentProfileConfiguration : IEntityTypeConfiguration<StudentProfile>
    {
        public void Configure(EntityTypeBuilder<StudentProfile> builder)
        {
            builder.ToTable("student_profiles");

            builder.HasKey(sp => sp.Id);

            builder.HasOne(sp => sp.User)
                   .WithOne(u => u.StudentProfile)
                   .HasForeignKey<StudentProfile>(sp => sp.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(sp => sp.Experience)
                   .HasColumnType("nvarchar(max)");

            builder.Property(sp => sp.Skills)
                   .HasColumnType("nvarchar(max)");

            builder.Property(sp => sp.ProgrammingLanguages)
                   .HasColumnType("nvarchar(max)");

            builder.Property(sp => sp.CoverLetter)
                   .HasColumnType("nvarchar(max)");

            builder.Property(sp => sp.PreferredLocation)
                   .HasMaxLength(100);

            builder.Property(sp => sp.Phone)
                   .HasMaxLength(20);
        }
    }
}
