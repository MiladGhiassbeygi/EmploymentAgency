using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.JobConfig
{
    internal class JobConfig : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.Property(e => e.Description).IsRequired();

            builder.Property(e => e.EssentialSkills).IsRequired();

            builder.Property(e => e.ExactAmountRecived).HasColumnType("money");

            builder.Property(e => e.SalaryMax).HasColumnType("money");

            builder.Property(e => e.SalaryMin).HasColumnType("money");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.UnnecessarySkills).IsRequired();

            builder.HasOne(d => d.Employer)
                .WithMany(p => p.Job)
                .HasForeignKey(d => d.EmployerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Job_EmployerInformation");
        }
    }
}
