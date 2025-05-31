using InternGo.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace InternGo.Infrastructure.Persistence.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("reviews");

            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.StudentProfile)
                   .WithMany(sp => sp.Reviews)
                   .HasForeignKey(r => r.StudentProfileId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Internship)
                   .WithMany()
                   .HasForeignKey(r => r.InternshipId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.Comment)
                   .HasColumnType("nvarchar(max)");

            builder.Property(r => r.Rating)
                   .IsRequired();

            builder.Property(r => r.PostedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }

}
