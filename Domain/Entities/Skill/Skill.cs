using Domain.Common;

namespace Domain.Entities
{
    public partial class Skill : BaseEntity<short>
    {
        public string Title { get; set; }
        public byte Percentage { get; set; }
    }
}
