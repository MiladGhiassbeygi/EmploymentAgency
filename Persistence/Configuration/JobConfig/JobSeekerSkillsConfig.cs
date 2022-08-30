using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.JobConfig
{
    internal class JobSeekerSkillsConfig : IEntityTypeConfiguration<JobSeekerSkills>
    {
        public void Configure(EntityTypeBuilder<JobSeekerSkills> builder)
        {
            builder.HasKey(x => new { x.SkillId, x.JobSeekerId });

            builder.Ignore(x => x.CreatedTime);
            builder.Ignore(x=> x.ModifiedDate);
            builder.Ignore(x=> x.Id);

            builder.HasOne(d => d.JobSeeker)
                .WithMany(d=> d.JobSeekerEssentialSkills)
                .HasForeignKey(d => d.JobSeekerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_JobSeekerSkills_JobSeeker");

            builder.HasOne(d => d.Skill)
                .WithMany(d=> d.JobSeekerSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_JobSeekerSkills_Skill");
        }
    }
}
