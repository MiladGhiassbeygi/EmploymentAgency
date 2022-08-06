namespace Web.Api.Dto.Reminder
{
    public class CreateReminderDto
    {
        public DateTime EventDate { get; set; }
        public string NoteTitle { get; set; }
        public string Note { get; set; }
        public string OwnerId { get; set; }
    }
}
