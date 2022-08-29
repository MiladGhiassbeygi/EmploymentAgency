using Domain.WriteModel.Common;

namespace Domain.WriteModel
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
        public bool IsFixed { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string HireCompanies { get; set; }
        public long EmployerId { get; set; }
        
        public virtual Employer Employer { get; set; }
        public virtual ICollection<JobCommission> JobCommission { get; set; }
        public virtual ICollection<JobEssentialSkills> JobEssentialSkills { get; set; }
        public virtual ICollection<JobUnnecessarySkills> JobUnnecessarySkills { get; set; }
        public virtual ICollection<SuccessedContract> SuccessedContract { get; set; } = new HashSet<SuccessedContract>();   
    }
}
