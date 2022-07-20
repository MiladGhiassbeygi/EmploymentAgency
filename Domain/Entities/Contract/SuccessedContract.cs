using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class SuccessedContract : BaseEntity<long>
    {
        public long EmployerId { get; set; }
        public long JobSeekerId { get; set; }
        public int EmploymentAgencyId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsAmountFixed { get; set; }
        public decimal Amount { get; set; }

        public virtual Employer Employer { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }
    }
}
