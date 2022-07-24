namespace Web.Api.Dto.Jobs
{
    public class CreateJobDto
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
