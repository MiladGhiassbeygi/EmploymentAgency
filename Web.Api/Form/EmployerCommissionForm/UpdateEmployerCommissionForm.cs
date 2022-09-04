namespace Web.Api.Form.EmployerCommissionForm
{
    public class UpdateEmployerCommissionForm
    {
        public long EmployerCommissionId { get; set; }
        public bool IsFixed { get; set; } = false;
        public int Value { get; set; }
    }
}
