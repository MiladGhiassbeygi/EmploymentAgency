using Domain.WriteModel.Common;

namespace Domain.WriteModel
{
    public partial class SuccessedContract : BaseEntity<long>
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsAmountFixed { get; set; }
        public decimal Amount { get; set; }
        public long JobId { get; set; }
        public long JobSeekerId { get; set; }
        public int ContractCreatorId { get; set; }

        public virtual Job Job { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }
        public User.User ContractCreator { get; set; }
    }
}
