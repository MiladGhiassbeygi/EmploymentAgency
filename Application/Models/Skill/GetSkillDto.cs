using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Skill
{
    public class GetSkillDto
    {
        public short Id { get; set; }
        public string Title { get; set; }
        public byte Percentage { get; set; }
    }
}
