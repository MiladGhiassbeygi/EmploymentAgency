using Domain.WriteModel.Common;
using System;
using System.Collections.Generic;

namespace Domain.WriteModel
{
    public partial class JobSeeker : BaseEntity<long>
    {
        public JobSeeker()
        {
            SuccessedContract = new HashSet<SuccessedContract>();
        }
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; }
        public string LinkedinAddress { get; set; }
        public string ResumeFilePath { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<SuccessedContract> SuccessedContract { get; set; }
    }
}
