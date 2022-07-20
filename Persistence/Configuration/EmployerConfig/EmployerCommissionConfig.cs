using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.EmployerConfig
{
    internal class EmployerCommissionConfig : IEntityTypeConfiguration<EmployerCommission>
    {
        public void Configure(EntityTypeBuilder<EmployerCommission> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.IsFixed)
                   .IsRequired()
                   .HasDefaultValueSql("((1))");

            builder.HasOne(d => d.Employer)
                .WithMany(p => p.EmployerCommission)
                .HasForeignKey(d => d.EmployerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployerCommission_EmployerInformation");
        }
    }
}
