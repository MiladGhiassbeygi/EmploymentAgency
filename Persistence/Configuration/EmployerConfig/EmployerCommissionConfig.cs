using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.JobConfig
{
    internal class EmployerCommissionConfig : IEntityTypeConfiguration<EmployerCommission>
    {
        public void Configure(EntityTypeBuilder<EmployerCommission> builder)
        {
            builder.HasOne(d => d.Employer)
                   .WithMany(p => p.EmployerCommission)
                   .HasForeignKey(d => d.EmployerId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_EmployerCommission_Employer");
        }
    }
}
