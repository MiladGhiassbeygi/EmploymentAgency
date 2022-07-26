using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class JobEssentialSkills : BaseEntity<int>
    {
        public long JobId { get; set; }
        public short SkillId { get; set; }

        public virtual Job Job { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
