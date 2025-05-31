using InternGo.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace InternGo.Infrastructure.Persistence.Configurations
{
    public class AdminLogConfiguration : IEntityTypeConfiguration<AdminLog>
    {
        public void Configure(EntityTypeBuilder<AdminLog> builder)
        {
            builder.ToTable("admin_logs");

            builder.HasKey(al => al.Id);

            builder.HasOne(al => al.Admin)
                   .WithMany(a => a.AdminLogs)
                   .HasForeignKey(al => al.AdminUserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(al => al.Action)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(al => al.TargetTable)
                   .HasMaxLength(100);

            builder.Property(al => al.Timestamp)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }

}
