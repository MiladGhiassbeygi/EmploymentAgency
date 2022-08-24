namespace Web.Api.Form.EmployerCommissionForm
{
    public class CreateEmployerCommissionForm
    {
        public bool IsFixed { get; set; } = false;
        public int Value { get; set; }
        public long EmployerId { get; set; }
    }
}
