namespace Web.Api.Form.Contract
{
    public class CreateContractForm
    {
        public long JobId { get; set; }
        public long JobSeekerId { get; set; }
        public int ContractCreatorId { get; set; }
        public bool IsAmountFixed { get; set; }
        public decimal Amount { get; set; }
    }
}




