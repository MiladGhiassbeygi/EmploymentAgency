using Domain.WriteModel.Common;

using System;
using System.Collections.Generic;

namespace Domain.WriteModel
{
    public partial class Employer : BaseEntity<long>
    {
        public Employer()
        {
            Job = new HashSet<Job>();
            SuccessedContract = new HashSet<SuccessedContract>();
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
      


        public virtual EmployerAcivityField FieldOfActivity { get; set; }
        public virtual ICollection<Job> Job { get; set; }
        public virtual ICollection<SuccessedContract> SuccessedContract { get; set; }
    }
}
