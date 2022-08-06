namespace Web.Api.Form.Reminder
{
    public class CreateReminderForm
    {
        public DateTime EventDate { get; set; }
        public string NoteTitle { get; set; }
        public string Note { get; set; }
        public string OwnerId { get; set; }
    }
}
