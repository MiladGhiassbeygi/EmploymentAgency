using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public class EmployerCommission
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }


        [BsonElement("employerCommissionId")]
        public long EmployerCommissionId { get; set; } 

        [BsonElement("isFixed")]
        public bool IsFixed { get; set; } = false;

        [BsonElement("value")]
        public int Value { get; set; }
        
        [BsonElement("employerId")]
        public long EmployerId { get; set; }

       
    }
}
