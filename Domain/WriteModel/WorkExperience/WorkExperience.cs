using Domain.WriteModel.Common;

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
        

        public long JobSeekerId { get; set; }

        public JobSeeker JobSeeker { get; set; }
    }
}
