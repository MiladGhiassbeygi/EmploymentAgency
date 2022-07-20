using Domain.Common;

namespace Domain.Entities
{
    public partial class EmployerCommission : BaseEntity<long>
    {
        public bool IsFixed { get; set; } = false;
        public int Value { get; set; }
        public long EmployerId { get; set; }

        public virtual Employer Employer { get; set; }
    }
}
