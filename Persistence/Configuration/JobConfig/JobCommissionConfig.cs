using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.JobConfig
{
    internal class JobCommissionConfig : IEntityTypeConfiguration<JobCommission>
    {
        public void Configure(EntityTypeBuilder<JobCommission> builder)
        {
            builder.HasOne(d => d.Job)
                   .WithMany(p => p.JobCommission)
                   .HasForeignKey(d => d.JobId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_JobCommission_JobDefinition");
        }
    }
}
