using Domain.Entities.Area;
using Domain.Entities.Employer;
using Domain.Entities.User;
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
        }
    }
}
