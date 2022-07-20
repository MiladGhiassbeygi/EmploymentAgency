using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.JobConfig
{
    internal class SuccessedContractConfig : IEntityTypeConfiguration<SuccessedContract>
    {
        public void Configure(EntityTypeBuilder<SuccessedContract> builder)
        {
            builder.Property(e => e.Amount).HasColumnType("money");

            builder.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.HasOne(d => d.Employer)
                .WithMany(p => p.SuccessedContract)
                .HasForeignKey(d => d.EmployerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SuccessedContract_Employer");

            builder.HasOne(d => d.JobSeeker)
                .WithMany(p => p.SuccessedContract)
                .HasForeignKey(d => d.JobSeekerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SuccessedContract_JobSeeker");
        }
    }
}
