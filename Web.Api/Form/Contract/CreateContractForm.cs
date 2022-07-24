namespace Web.Api.Form.Contract
{
    public class CreateContractForm
    {
        public long Id { get; set; }
        public long EmployerId { get; set; }
        public long JobSeekerId { get; set; }
        public int EmploymentAgencyId { get; set; }
        public bool IsAmountFixed { get; set; }
        public decimal Amount { get; set; }
    }
}




