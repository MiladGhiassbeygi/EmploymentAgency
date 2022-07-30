using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public class JobEssentialSkills 
    {
        [BsonElement("jobId")]
        public long JobId { get; set; }
        [BsonElement("skillId")]
        public short SkillId { get; set; }
    }
}
