using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public class EmployerAcivityField 
    {
      
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("employerAcivityFieldId")]
        public byte EmployerAcivityFieldId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("definerId")]
        public long DefinerId { get; set; }

    }
}
