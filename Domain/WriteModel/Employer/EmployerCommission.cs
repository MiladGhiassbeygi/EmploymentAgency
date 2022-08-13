using Domain.WriteModel.Common;

namespace Domain.WriteModel
{
    public partial class EmployerCommission : BaseEntity<long>
    {
        public bool IsFixed { get; set; }
        public int Value { get; set; }
        public long EmployerId { get; set; }

        public virtual Employer Employer { get; set; }
    }
}
