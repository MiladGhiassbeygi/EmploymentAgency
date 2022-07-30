using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.JobConfig
{
    internal class JobEssentialSkillsConfig : IEntityTypeConfiguration<JobEssentialSkills>
    {
        public void Configure(EntityTypeBuilder<JobEssentialSkills> builder)
        {
            builder.HasNoKey();

            builder.Ignore(x => x.CreatedTime);
            builder.Ignore(x=> x.ModifiedDate);
            builder.Ignore(x=> x.Id);

            builder.HasOne(d => d.Job)
                .WithMany()
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobEssentialSkills_Job");

            builder.HasOne(d => d.Skill)
                .WithMany()
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobEssentialSkills_Skill");
        }
    }
}
