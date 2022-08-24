using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public class JobCommission 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("jobCommissionId")]
        public long JobCommissionId { get; set; }

        [BsonElement("isFixed")]
        public bool IsFixed { get; set; } = false;

        [BsonElement("value")]
        public int Value { get; set; }
        
        [BsonElement("jobId")]
        public long JobId { get; set; }

       
    }
}
