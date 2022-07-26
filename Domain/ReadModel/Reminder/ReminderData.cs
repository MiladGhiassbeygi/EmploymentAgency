using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public class ReminderData 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public int Id { get; set; }

        [BsonElement("eventDate")]
        public DateTime EventDate { get; set; }
        [BsonElement("notetitle")]
        public string NoteTitle { get; set; }

        [BsonElement("note")]
        public string Note { get; set; }

        [BsonElement("ownerId")]
        public string OwnerId { get; set; }
    }
}
