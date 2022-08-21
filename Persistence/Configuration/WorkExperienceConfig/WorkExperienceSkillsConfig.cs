using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.AreaConfig
{
    internal class WorkExperienceSkillsConfig : IEntityTypeConfiguration<WorkExperienceSkill>
    {
        public void Configure(EntityTypeBuilder<WorkExperienceSkill> builder)
        {
            builder.HasKey(x => new { x.SkillId, x.WorkExperienceId });

            builder.Ignore(x => x.CreatedTime);
            builder.Ignore(x => x.ModifiedDate);
            builder.Ignore(x => x.Id);

            builder.HasOne(d => d.Skill)
                .WithMany()
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Skill_WorkExperience");

            builder.HasOne(d => d.WorkExperience)
                .WithMany()
                .HasForeignKey(d => d.WorkExperienceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkExperience_Skill");
        }
    }
}
