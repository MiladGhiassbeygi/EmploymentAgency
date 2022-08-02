using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public class Employer 
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("EmployerId")]
        public long EmployerId { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("websiteLink")]
        public string WebsiteLink { get; set; }

        [BsonElement("necessaryExplanation")]
        public string NecessaryExplanation { get; set; }

        [BsonElement("fieldOfActivityId")]
        public byte FieldOfActivityId { get; set; }

       
    }
}




