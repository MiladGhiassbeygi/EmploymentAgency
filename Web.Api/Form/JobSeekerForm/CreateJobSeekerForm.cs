namespace Web.Api.Form.JobSeekerForm
{
    public class CreateJobSeekerForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; }
        public string LinkedinAddress { get; set; }
        public string ResumeFilePath { get; set; }
        public short[] SkillIds { get; set; }
    }
}
