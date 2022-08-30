using Domain.WriteModel.Common;


namespace Domain.WriteModel
{
    public partial class JobSeekerSkills : BaseEntity<int>
    { 
        public long? JobSeekerId { get; set; }
        public short? SkillId { get; set; }

        public virtual JobSeeker JobSeeker { get; set; }
        public virtual Skill Skill { get; set; }
    }

}
