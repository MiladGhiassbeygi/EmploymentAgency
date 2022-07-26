using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public partial class Skill
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public short Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("percentage")]
        public byte Percentage { get; set; }
    }
}
