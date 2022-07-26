using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Domain.ReadModel
{
    public class Country 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public int Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("postalCode")]
        public string PostalCode { get; set; }
        
        [BsonElement("areaCode")]
        public string AreaCode { get; set; }

    }
}
