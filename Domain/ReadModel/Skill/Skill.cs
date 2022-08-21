using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public partial class Skill
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("skillId")]
        public short SkillId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("percentage")]
        public byte Percentage { get; set; }
    }
}
