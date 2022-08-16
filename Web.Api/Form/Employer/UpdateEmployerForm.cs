namespace Web.Api.Form.Employer
{
    public class UpdateEmployerForm
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WebsiteLink { get; set; }
        public string NecessaryExplanation { get; set; }
        public bool IsFixed { get; set; }
        public decimal ExactAmountRecived { get; set; }
        public byte FieldOfActivityId { get; set; }
        public int DefinerId { get; set; }
    }
}
