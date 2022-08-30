namespace Web.Api.Form.Contract
{
    public class CreateContractForm
    {
        public long Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsAmountFixed { get; set; }
        public decimal Amount { get; set; }
        public long JobId { get; set; }
        public long JobSeekerId { get; set; }
        public int ContractCreatorId { get; set; }
    }
}




