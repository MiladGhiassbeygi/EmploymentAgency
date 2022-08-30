using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public class JobSeekerEssentialSkills
    {
        [BsonElement("jobSeekerId")]
        public long JobSeekerId { get; set; }
        [BsonElement("skillId")]
        public short SkillId { get; set; }
    }
}
