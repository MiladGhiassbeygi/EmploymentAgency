namespace Web.Api.Form
{
    public class UpdateEducationalBackgroundForm
    {
        public int Id { get; set; }
        public string School { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long JobSeekerId { get; set; }
    }
}
