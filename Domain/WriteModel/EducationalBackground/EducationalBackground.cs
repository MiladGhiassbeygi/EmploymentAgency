using Domain.WriteModel.Common;

namespace Domain.WriteModel
{
    public partial class EducationalBackground : BaseEntity<int>
    {

        public DateTime EventDate { get; set; }
        public string NoteTitle { get; set; }
        public string Note { get; set; }
        public string OwnerId { get; set; }
    }
}
