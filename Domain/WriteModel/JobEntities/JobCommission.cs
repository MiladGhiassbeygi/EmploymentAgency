using Domain.WriteModel.Common;

namespace Domain.WriteModel
{
    public partial class JobCommission : BaseEntity<long>
    {
        public bool IsFixed { get; set; } = false;
        public int Value { get; set; }
        public long JobId { get; set; }

        public virtual Job Job { get; set; }
    }
}
