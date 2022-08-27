using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.ReadModel
{
    public  class SuccessedContract 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public long Id { get; set; }
        [BsonElement("employerId")]
        public long EmployerId { get; set; }
        [BsonElement("jobSeekerId")]
        public long JobSeekerId { get; set; }
        [BsonElement("contractCreatorId")]
        public int ContractCreatorId { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; } = DateTime.Now;
        [BsonElement("isAmountFixed")]
        public bool IsAmountFixed { get; set; }
        [BsonElement("amount")]
        public decimal Amount { get; set; }

    }
}
