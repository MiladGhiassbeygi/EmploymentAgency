﻿using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public class JobSeekerSkills
    {
        [BsonElement("jobSeekerId")]
        public long JobSeekerId { get; set; }
        [BsonElement("skillId")]
        public short SkillId { get; set; }
    }
}
