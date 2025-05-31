using InternGo.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace InternGo.Infrastructure.Persistence.Configurations
{
    public class CompanyProfileConfiguration : IEntityTypeConfiguration<CompanyProfile>
    {
        public void Configure(EntityTypeBuilder<CompanyProfile> builder)
        {
            builder.ToTable("company_profiles");

            builder.HasKey(cp => cp.Id);

            builder.HasOne(cp => cp.User)
                   .WithOne(u => u.CompanyProfile)
                   .HasForeignKey<CompanyProfile>(cp => cp.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(cp => cp.CompanyName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(cp => cp.Location)
                   .HasMaxLength(100);

            builder.Property(cp => cp.Website)
                   .HasMaxLength(100);

            builder.Property(c => c.MaxTrainees)
       .IsRequired();

            builder.Property(c => c.WorkingHours)
                   .HasMaxLength(100)
                   .IsRequired();

        }
    }

}
