using Domain.WriteModel.Common;

namespace Domain.WriteModel
{
    public partial class ReminderData : BaseEntity<long>
    {
        public DateTime EventDate { get; set; }
        public string NoteTitle { get; set; }
        public string Note { get; set; }
        public string OwnerId { get; set; }
    }
}
