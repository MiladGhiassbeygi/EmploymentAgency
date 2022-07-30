using Domain.WriteModel.Common;

namespace Domain.WriteModel
{
    public partial class Skill : BaseEntity<short>
    {
        public string Title { get; set; }
        public byte Percentage { get; set; }
    }
}
