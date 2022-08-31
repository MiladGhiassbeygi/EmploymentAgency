using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public class ReminderData 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("ReminderId")]
        public long ReminderId { get; set; }
        [BsonElement("eventDate")]
        public DateTime EventDate { get; set; }
        [BsonElement("notetitle")]
        public string NoteTitle { get; set; }

        [BsonElement("note")]
        public string Note { get; set; }

        [BsonElement("ownerId")]
        public int OwnerId { get; set; }
    }
}
