using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.EmployerConfig
{
    internal class EmployerAcivityFieldConfig : IEntityTypeConfiguration<EmployerAcivityField>
    {
        public void Configure(EntityTypeBuilder<EmployerAcivityField> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Title).IsRequired();

            builder.Property(x => x.DefinerId)
                .HasDefaultValue(0);

            builder.HasOne(x => x.Definer)
                .WithMany(x => x.EmployerAcivityFields)
                .HasForeignKey(x => x.DefinerId);

        }
    }
}
