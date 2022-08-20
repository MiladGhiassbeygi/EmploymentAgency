using Domain.WriteModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WriteModel
{
    public class WorkExperience : BaseEntity<int>
    {
        public string JobTitle { get; set; }
        public int HoursOfWork { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SalaryPaid { get; set; }
        public string TypeOfCooperation { get; set; }
        public string HireCompanies { get; set; }
        public string Skills { get; set; }

        public long JobSeekerId { get; set; }

        public JobSeeker JobSeeker { get; set; }
    }
}
