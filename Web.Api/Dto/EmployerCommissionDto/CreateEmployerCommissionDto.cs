namespace Web.Api.Dto.EmployerCommissionDto
{
    public class CreateEmployerCommissionDto
    {
        public bool IsFixed { get; set; } = false;
        public int Value { get; set; }
        public long EmployerId { get; set; }
    }
}
