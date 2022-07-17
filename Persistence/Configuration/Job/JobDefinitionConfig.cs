using Domain.Entities.Area;
using Domain.Entities.Employer;
using Domain.Entities.Job;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.JobConfig
{
    internal class JobDefinitionConfig : IEntityTypeConfiguration<JobDefinition>
    {
        public void Configure(EntityTypeBuilder<JobDefinition> builder)
        {
            builder.Property(e => e.Description).IsRequired();

            builder.Property(e => e.EssentialSkills).IsRequired();

            builder.Property(e => e.ExactAmountRecived).HasColumnType("money");

            builder.Property(e => e.SalaryFixed).HasColumnType("money");

            builder.Property(e => e.SalaryMax).HasColumnType("money");

            builder.Property(e => e.SalaryMin).HasColumnType("money");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.UnnecessarySkills).IsRequired();
        }
    }
}
