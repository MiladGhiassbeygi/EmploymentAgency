using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.JobConfig
{
    internal class JobSeekerUnnessecarySkillsConfig : IEntityTypeConfiguration<JobSeekerUnnessecarySkills>
    {
        public void Configure(EntityTypeBuilder<JobSeekerUnnessecarySkills> builder)
        {
            builder.HasKey(x => new { x.SkillId, x.JobSeekerId });

            builder.Ignore(x => x.CreatedTime);
            builder.Ignore(x=> x.ModifiedDate);
            builder.Ignore(x=> x.Id);

            builder.HasOne(d => d.Job)
                .WithMany(d=> d.JobSeekerUnnecessarySkills)
                .HasForeignKey(d => d.JobSeekerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_JobSeekerUnnecessarySkills_JobSeeker");

            builder.HasOne(d => d.Skill)
                .WithMany(d=> d.JobSeekerUnnecessarySkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_JobSeekerUnnecessarySkills_Skill");
        }
    }
}
