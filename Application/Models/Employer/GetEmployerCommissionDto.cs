namespace Application.Models.Employer
{
    public class GetEmployerCommissionDto
    {
        public bool IsFixed { get; set; } = false;
        public int Value { get; set; }
        public long EmployerId { get; set; }
    }
}
