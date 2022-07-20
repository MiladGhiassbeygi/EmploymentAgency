using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.EmployerConfig
{
    internal class EmployerConfig : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(15);


            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(e => e.NecessaryExplanation).IsRequired();

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.WebsiteLink)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasOne(d => d.FieldOfActivity)
                .WithMany(p => p.EmployerDetails)
                .HasForeignKey(d => d.FieldOfActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employer_EmployerAcivityField");
        }
    }
}
