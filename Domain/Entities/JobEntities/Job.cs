using Domain.Common;

namespace Domain.Entities
{
    public partial class Job : BaseEntity<long>
    {
        public Job()
        {
            JobCommission = new HashSet<JobCommission>();
        }
        public long Id { get; set; }
        public string Title { get; set; }
        public int HoursOfWork { get; set; }
        public decimal SalaryMin { get; set; }
        public decimal SalaryMax { get; set; }
        public byte AnnualLeave { get; set; }
        public decimal ExactAmountRecived { get; set; }
        public string Description { get; set; }
        public string EssentialSkills { get; set; }
        public string UnnecessarySkills { get; set; }
        public long EmployerId { get; set; }

        public virtual Employer Employer { get; set; }
        public virtual ICollection<JobCommission> JobCommission { get; set; }
    }
}
