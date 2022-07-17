using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Job
{
    public partial class JobDefinition : BaseEntity<long>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int HoursOfWork { get; set; }
        public decimal SalaryMin { get; set; }
        public decimal SalaryMax { get; set; }
        public byte AnnualLeave { get; set; }
        public byte? SalaryByPercent { get; set; }
        public decimal? SalaryFixed { get; set; }
        public decimal ExactAmountRecived { get; set; }
        public string Description { get; set; }
        public string EssentialSkills { get; set; }
        public string UnnecessarySkills { get; set; }
    }
}
