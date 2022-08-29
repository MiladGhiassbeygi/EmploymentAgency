using Domain.WriteModel;
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
                .HasDefaultValue(DateTime.Now);

            builder.HasOne(d => d.Job)
                .WithMany(p => p.SuccessedContract)
            
                .HasConstraintName("FK_SuccessedContract_Job");

            builder.HasOne(d => d.JobSeeker)
                .WithMany(p => p.SuccessedContract)
                .HasConstraintName("FK_SuccessedContract_JobSeeker");

        }
    }
}