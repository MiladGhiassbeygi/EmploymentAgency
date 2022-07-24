using Domain.Common;

namespace Domain.Entities
{
    public partial class Country : BaseEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostalCode { get; set; }
        public string AreaCode { get; set; }

        public virtual ICollection<JobSeeker> JobSeeker { get; set; }
    }
}
