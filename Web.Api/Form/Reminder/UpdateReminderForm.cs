namespace Web.Api.Form.Reminder
{
    public class UpdateReminderForm
    {
        public long ReminderId { get; set; }
        public DateTime EventDate { get; set; }
        public string NoteTitle { get; set; }
        public string Note { get; set; }
    }
}
