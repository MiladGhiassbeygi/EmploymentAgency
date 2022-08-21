namespace Web.Api.Form.Job
{
    public class CreateJobForm
    {
        public string Title { get; set; }
        public int HoursOfWork { get; set; }
        public decimal SalaryMin { get; set; }
        public decimal SalaryMax { get; set; }
        public byte AnnualLeave { get; set; }
        public bool IsFixed { get; set; }
        public decimal ExactAmountRecived { get; set; }
        public string Description { get; set; }
        public string EssentialSkills { get; set; }
        public string UnnecessarySkills { get; set; }
        public string Email { get; set; }
        public string HireCompanies { get; set; }
        public long EmployerId { get; set; }
    }
}
