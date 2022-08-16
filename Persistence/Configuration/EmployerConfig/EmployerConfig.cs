using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.EmployerConfig
{
    internal class EmployerConfig : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("text");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("text");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("text");


            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnType("text");

            builder.Property(e => e.NecessaryExplanation).IsRequired();

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("text");

            builder.Property(e => e.WebsiteLink)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("text");

            builder.HasOne(d => d.FieldOfActivity)
                .WithMany(p => p.EmployerDetails)
                .HasForeignKey(d => d.FieldOfActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employer_EmployerAcivityField");

            builder.HasOne(d => d.Definer)
                .WithMany(d => d.Employers)
                .HasForeignKey(d => d.DefinerId)
                .HasConstraintName("FK_Employer_EmployerDefiner");

        }
    }
}
