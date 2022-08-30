
using Domain.WriteModel.Common;

namespace Domain.WriteModel
{
    public partial class JobUnnessecarySkills : BaseEntity<int>
    {
        public long? JobId { get; set; }
        public short? SkillId { get; set; }

        public virtual Job Job { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
