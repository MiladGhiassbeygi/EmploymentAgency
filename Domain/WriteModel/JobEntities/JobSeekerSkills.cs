using Domain.WriteModel.Common;


namespace Domain.WriteModel
{
<<<<<<<< HEAD:Domain/WriteModel/JobEntities/JobSeekerSkills.cs
    public partial class JobSeekerSkills : BaseEntity<int>
========
    public partial class JobSeekerUnnessecarySkills : BaseEntity<int>
>>>>>>>> f49fc2683ec823171bdb9b77f9c05c762c411ef0:Domain/WriteModel/JobEntities/JobSeekerUnnessecarySkills.cs
    {
        public long? JobSeekerId { get; set; }
        public short? SkillId { get; set; }

        public virtual JobSeeker JobSeeker { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
