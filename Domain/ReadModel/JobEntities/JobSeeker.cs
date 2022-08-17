using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public class JobSeeker 
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("jobSeekerId")]
        public long JobSeekerId { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("countryId")]
        public int CountryId { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("linkedinAddress")]
        public string LinkedinAddress { get; set; }

        [BsonElement("resumeFilePath")]
        public string ResumeFilePath { get; set; }

        [BsonElement("definerId")]
        public int DefinerId { get; set; }

    }
}
