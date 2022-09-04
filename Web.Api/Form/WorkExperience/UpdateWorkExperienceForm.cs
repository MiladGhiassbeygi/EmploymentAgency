namespace Web.Api.Form.WorkExperience
{
    public class UpdateWorkExperienceForm
    {
        public int WorkExperienceId { get; set; }
        public string JobTitle { get; set; }
        public int HoursOfWork { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SalaryPaid { get; set; }
        public string TypeOfCooperation { get; set; }
        public string HireCompanies { get; set; }
    }
}
