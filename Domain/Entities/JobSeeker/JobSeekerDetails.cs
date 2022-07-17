using Domain.Common;
using Domain.Entities.Area;
using System;
using System.Collections.Generic;

namespace Domain.Entities.JobSeeker
{
    public partial class JobSeekerDetails : BaseEntity<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; }
        public string LinkedinAddress { get; set; }
        public string ResumeFilePath { get; set; }

        public virtual Country Country { get; set; }
    }
}
