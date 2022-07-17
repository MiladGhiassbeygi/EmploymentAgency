using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Employer
{
    public partial class EmployerDetails : BaseEntity<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WebsiteLink { get; set; }
        public string NecessaryExplanation { get; set; }
        public decimal? JobSalaryFixed { get; set; }
        public byte? JobSalaryByPercent { get; set; }
        public byte FieldOfActivityId { get; set; }

        public virtual EmployerAcivityField FieldOfActivity { get; set; }
    }
}
