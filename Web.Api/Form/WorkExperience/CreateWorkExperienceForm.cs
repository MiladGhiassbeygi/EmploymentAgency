namespace Web.Api.Form.WorkExperienceForm
{
    public class CreateWorkExperienceForm
    {
        public string JobTitle { get; set; }
        public int HoursOfWork { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SalaryPaid { get; set; }
        public string TypeOfCooperation { get; set; }
        public string HireCompanies { get; set; }
        public short[] SkillIds { get; set; }

        public long JobSeekerId { get; set; }

    }
}
