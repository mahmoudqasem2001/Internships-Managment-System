using InternGo.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace InternGo.Infrastructure.Persistence.Configurations
{
    public class AIRecommendationConfiguration : IEntityTypeConfiguration<AIRecommendation>
    {
        public void Configure(EntityTypeBuilder<AIRecommendation> builder)
        {
            builder.ToTable("ai_recommendations");

            builder.HasKey(ar => ar.Id);

            builder.HasOne(ar => ar.StudentProfile)
                   .WithMany(sp => sp.AIRecommendations)
                   .HasForeignKey(ar => ar.StudentProfileId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ar => ar.Internship)
                   .WithMany()
                   .HasForeignKey(ar => ar.InternshipId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ar => ar.MatchScore)
                   .IsRequired();

            builder.Property(ar => ar.RecommendedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }

}
