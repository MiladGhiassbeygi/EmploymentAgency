

using Domain.WriteModel.Common;

namespace Domain.WriteModel
{
    public class WorkExperienceSkill : BaseEntity<short>
    {
        public short SkillId { get; set; }
        public int WorkExperienceId { get; set; }

        public Skill Skill { get; set; }
        public WorkExperience WorkExperience { get; set; }
    }
}
