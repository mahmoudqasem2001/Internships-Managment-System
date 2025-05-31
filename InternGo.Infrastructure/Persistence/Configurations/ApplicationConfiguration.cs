using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using InternGo.Domain.Entities;

namespace InternGo.Infrastructure.Persistence.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<InternshipApplication>
    {
        public void Configure(EntityTypeBuilder<InternshipApplication> builder)
        {
            builder.ToTable("applications");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.StudentProfile)
                   .WithMany(sp => sp.Applications)
                   .HasForeignKey(a => a.StudentProfileId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Internship)
                   .WithMany(i => i.Applications)
                   .HasForeignKey(a => a.InternshipId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(a => a.Status)
                   .HasMaxLength(50)
                   .HasDefaultValue("Pending");

            builder.Property(a => a.AppliedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }

}
