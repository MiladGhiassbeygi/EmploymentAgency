namespace Application.BackgroundWorker.Common.Events
{
    public class SuccessedContractAdded
    {
        public long SuccessedContractId { get; set; }
        public long EmployerId { get; set; }
    }
}
