namespace Web.Api.Form.Employer
{
    public class CreateEmployerForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WebsiteLink { get; set; }
        public string NecessaryExplanation { get; set; }
        public string ExactAmountRecived { get; set; }
        public bool IsFixed { get; set; }
        public byte FieldOfActivityId { get; set; }
    }
}
