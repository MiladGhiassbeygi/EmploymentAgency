using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Job
{
    public class GetJobsDto
    {
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
    }
}
