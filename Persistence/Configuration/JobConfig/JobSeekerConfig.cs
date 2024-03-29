﻿using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.JobConfig
{
    internal class JobSeekerConfig : IEntityTypeConfiguration<JobSeeker>
    {
        public void Configure(EntityTypeBuilder<JobSeeker> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

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
                .WithMany(p => p.JobSeeker)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobSeeker_Country");

            builder.HasMany(d => d.WorkExperiences)
                .WithOne(d => d.JobSeeker)
                .HasForeignKey(x => x.JobSeekerId)
                .HasConstraintName("FK_JobSeeker_JobseekerWorkExperience");

            builder.HasMany(d => d.EducationalBackgrounds)
             .WithOne(d => d.JobSeeker)
             .HasForeignKey(x => x.JobSeekerId)
             .HasConstraintName("FK_JobSeeker_JobseekerEducationalBackground");

            builder.HasOne(d => d.Definer)
              .WithMany(d => d.JobSeekers)
              .HasForeignKey(d => d.DefinerId)
              .HasConstraintName("FK_JobSeeker_JobSeekerDefiner");

            
                
            
        }
    }
}
