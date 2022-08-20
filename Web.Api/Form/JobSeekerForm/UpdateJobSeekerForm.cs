namespace Web.Api.Form.JobSeekerForm
{
    public class UpdateJobSeekerForm
    {
        public long JobSeekerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; }
        public string LinkedinAddress { get; set; }
        public string ResumeFilePath { get; set; }
    }
}
