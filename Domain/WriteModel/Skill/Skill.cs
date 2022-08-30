using Domain.WriteModel.Common;

namespace Domain.WriteModel
{
    public partial class Skill : BaseEntity<short>
    {
        public string Title { get; set; }
        public byte Percentage { get; set; }
        public virtual ICollection<JobEssentialSkills> JobEssentialSkills { get; set; }
        public virtual ICollection<JobUnnecessarySkills> JobUnnecessarySkills { get; set; }
        public virtual ICollection<JobSeekerEssentialSkills> JobSeekerEssentialSkills { get; set; }
        public virtual ICollection<JobSeekerUnnecessarySkills> JobSeekerUnnecessarySkills { get; set; }
    }
}
