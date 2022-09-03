using Domain.WriteModel.Common;

namespace Domain.WriteModel
{
    public partial class Skill : BaseEntity<short>
    {
        public string Title { get; set; }
        public virtual ICollection<JobEssentialSkills> JobEssentialSkills { get; set; }
        public virtual ICollection<JobUnnessecarySkills> JobUnnecessarySkills { get; set; }
        public virtual ICollection<JobSeekerSkills> JobSeekerSkills { get; set; }
    }
}
