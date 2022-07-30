
namespace Domain.WriteModel
{
    public partial class JobUnnecessarySkills
    {
        public long JobId { get; set; }
        public short SkillId { get; set; }

        public virtual Job Job { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
