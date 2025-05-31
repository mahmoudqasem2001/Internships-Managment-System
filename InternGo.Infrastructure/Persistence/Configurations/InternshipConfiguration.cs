using InternGo.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace InternGo.Infrastructure.Persistence.Configurations
{
    public class InternshipConfiguration : IEntityTypeConfiguration<Internship>
    {
        public void Configure(EntityTypeBuilder<Internship> builder)
        {
            builder.ToTable("internships");

            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.CompanyProfile)
                   .WithMany(cp => cp.Internships)
                   .HasForeignKey(i => i.CompanyProfileId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(i => i.Title)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(i => i.Description)
                   .HasColumnType("nvarchar(max)");

            builder.Property(i => i.SkillsRequired)
                   .HasColumnType("nvarchar(max)");

            builder.Property(i => i.Capacity)
                   .IsRequired();

            builder.Property(i => i.Deadline)
                   .IsRequired();
        }
    }

}
