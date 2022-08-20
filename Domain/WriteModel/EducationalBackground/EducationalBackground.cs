using Domain.WriteModel.Common;

namespace Domain.WriteModel
{
    public partial class EducationalBackground : BaseEntity<int>
    {
        public string School { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public long JobSeekerId { get; set; }

        public virtual JobSeeker JobSeeker { get; set; }
    }
}
