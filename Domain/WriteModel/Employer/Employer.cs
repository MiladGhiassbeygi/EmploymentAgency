using Domain.WriteModel.Common;

namespace Domain.WriteModel
{
    public partial class Employer : BaseEntity<long>
    {
        public Employer()
        {
            Job = new HashSet<Job>();
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WebsiteLink { get; set; }
        public string NecessaryExplanation { get; set; }
        public bool IsFixed { get; set; }
        public decimal ExactAmountRecived { get; set; }
        public byte FieldOfActivityId { get; set; }
        public int DefinerId { get; set; }

        public virtual EmployerAcivityField FieldOfActivity { get; set; }
        public virtual User.User Definer { get; set; }
        public virtual ICollection<Job> Job { get; set; }
        public virtual ICollection<SuccessedContract> SuccessContract { get; set; }
        public virtual ICollection<EmployerCommission> EmployerCommission { get; set; }
    }
}
