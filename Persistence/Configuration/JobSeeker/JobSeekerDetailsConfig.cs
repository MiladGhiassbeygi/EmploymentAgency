using Domain.Entities.Area;
using Domain.Entities.Employer;
using Domain.Entities.JobSeeker;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.JobConfig
{
    internal class JobSeekerDetailsConfig : IEntityTypeConfiguration<JobSeekerDetails>
    {
        public void Configure(EntityTypeBuilder<JobSeekerDetails> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.LinkedinAddress)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.ResumeFilePath).IsRequired();

            builder.HasOne(d => d.Country)
                .WithMany()
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobSeekerDetails_Country");
        }
    }
}
