using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.JobConfig
{
    internal class JobUnnessecarySkillsConfig : IEntityTypeConfiguration<JobUnnessecarySkills>
    {
        public void Configure(EntityTypeBuilder<JobUnnessecarySkills> builder)
        {
            builder.HasKey(x => new { x.SkillId, x.JobId });

            builder.Ignore(x => x.CreatedTime);
            builder.Ignore(x=> x.ModifiedDate);
            builder.Ignore(x=> x.Id);

            builder.HasOne(d => d.Job)
                .WithMany(d=> d.JobUnnecessarySkills)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_JobUnnecessarySkills_Job");

            builder.HasOne(d => d.Skill)
                .WithMany(d=> d.JobUnnessecarySkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_JobUnnecessarySkills_Skill");
        }
    }
}
