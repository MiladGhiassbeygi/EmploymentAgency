namespace Web.Api.Form.JobCommissionForm
{
    public class CreateJobCommissionForm
    {
        public bool IsFixed { get; set; } = false;
        public int Value { get; set; }
        public long JobId { get; set; }
    }
}
