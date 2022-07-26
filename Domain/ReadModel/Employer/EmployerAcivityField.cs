using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public class EmployerAcivityField 
    {
      
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public byte Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

    }
}
