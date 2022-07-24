namespace Web.Api.Dto.JobCommissionsDto
{
    public class GetJobCommissionsDto
    {
        public bool IsFixed { get; set; } = false;
        public int Value { get; set; }
        public long JobId { get; set; }
    }
}
