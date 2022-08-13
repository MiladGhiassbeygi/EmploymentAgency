using Domain.WriteModel;
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
                   .HasDefaultValue(true);

            builder.HasOne(d => d.Employer)
                .WithMany(p => p.EmployerCommission)               
                .HasConstraintName("FK_EmployerCommission_EmployerInformation");
        }
    }
}


 //.HasForeignKey(d => d.EmployerId)
 //               .OnDelete(DeleteBehavior.ClientSetNull)