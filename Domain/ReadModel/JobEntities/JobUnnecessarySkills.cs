
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public class JobUnnecessarySkills
    {
        [BsonElement("jobId")]
        public long JobId { get; set; }
        [BsonElement("skillId")]
        public short SkillId { get; set; }
    }
}
